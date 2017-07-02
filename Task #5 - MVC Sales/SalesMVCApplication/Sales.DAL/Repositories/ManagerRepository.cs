using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class ManagerRepository : IRepository<Manager>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public ManagerRepository(Sales.Model.Models.SalesDataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Manager> GetAll()
        {
            return _context.Managers;
        }
        public int Count()
        {
             return _context.Managers.Count();
        }
        public Manager Get(int id)
        {
            return _context.Managers.Find(id);
        }

        public void Create(Manager item)
        {
            Sales.Model.Models.Manager manager = _context.Managers.Find(item.ID);
            if (manager == null)
                _context.Managers.Add(item);
        }

        public void Update(Manager item)
        {
            Sales.Model.Models.Manager manager = _context.Managers.Find(item.ID);
            if (manager != null)
            {
                manager.Name = item.Name;
                _context.Entry<Manager>(manager).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Manager manager = _context.Managers.Find(id);
            if (manager != null)
                _context.Managers.Remove(manager);
        }
    }
}
