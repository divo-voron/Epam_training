using Sales.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    abstract class AbstractRepository<T> : IRepository<T>
        where T : class
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public AbstractRepository(Sales.Model.Models.SalesDataBaseContext context)
        {
            _context = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }
        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Create(T item)
        {
            var entity = _context.Set<T>().Find(item);
            if (entity == null)
                _context.Set<T>().Add(item);
            else
                throw new ArgumentException("Items already exists");
        }

        public virtual void Update(T item)
        {
            var entity = _context.Set<T>().Find(item);
            if (entity != null)
            {
                //entity.Name = item.Name;
                _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            }
            else
                throw new ArgumentException("Item with this ID not found");
        }

        public virtual void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
                _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
        }   
    }
}
