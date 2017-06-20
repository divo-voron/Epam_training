using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class SessionRepository : IRepository<Session>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public SessionRepository(Sales.Model.Models.SalesDataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Session> GetAll()
        {
            return _context.Sessions;
        }

        public Session Get(int id)
        {
            return _context.Sessions.FirstOrDefault(x => x.ID == id);
        }

        public void Create(Session item)
        {
            Sales.Model.Models.Session session = _context.Sessions.FirstOrDefault(x => x.ID == item.ID);
            if (session == null)
                _context.Sessions.Add(item);
        }

        public void Update(Session item)
        {
            Sales.Model.Models.Session session = _context.Sessions.FirstOrDefault(x => x.ID == item.ID);
            if (session != null)
            {
                session.Name = item.Name;
                session.Date = item.Date;
                _context.Entry<Session>(session).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Session session = _context.Sessions.FirstOrDefault(x => x.ID == id);
            if (session != null)
                _context.Sessions.Remove(session);
        }
    }
}
