using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class ClientRepository : IRepository<Client>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public ClientRepository(Sales.Model.Models.SalesDataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Client> GetAll()
        {
            return _context.Clients;
        }
        public int Count()
        {
            return _context.Clients.Count();
        }
        public Client Get(int id)
        {
            return _context.Clients.Find(id);
        }

        public void Create(Client item)
        {
            Sales.Model.Models.Client client = _context.Clients.Find(item.ID);
            if (client == null)
                _context.Clients.Add(item);
            else
                throw new ArgumentException("Сlient with this ID already exists");
        }

        public void Update(Client item)
        {
            Sales.Model.Models.Client client = _context.Clients.Find(item.ID);
            if (client != null)
            {
                client.Name = item.Name;
                _context.Entry<Client>(client).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Client client = _context.Clients.Find(id);
            if (client != null)
                _context.Clients.Remove(client);
        }
    }
}
