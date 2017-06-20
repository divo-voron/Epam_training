using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class ManagerRepository:IRepository<Manager>
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

        public Manager Get(int id)
        {
            return _context.Managers.FirstOrDefault(x => x.ID == id);
        }

        public void Create(Manager item)
        {
            Sales.Model.Models.Manager manager = _context.Managers.FirstOrDefault(x => x.ID == item.ID);
            if (manager == null)
                _context.Managers.Add(item);
        }

        public void Update(Manager item)
        {
            Sales.Model.Models.Manager manager = _context.Managers.FirstOrDefault(x => x.ID == item.ID);
            if (manager != null)
            {
                manager.Name = item.Name;
                _context.Entry<Manager>(manager).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Manager manager = _context.Managers.FirstOrDefault(x => x.ID == id);
            if (manager != null)
                _context.Managers.Remove(manager);
        }
    }
}
