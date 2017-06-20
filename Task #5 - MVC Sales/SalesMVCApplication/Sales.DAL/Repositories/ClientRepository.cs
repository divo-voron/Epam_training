using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class ClientRepository : IRepository<Client>
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

        public Client Get(int id)
        {
            return _context.Clients.FirstOrDefault(x => x.ID == id);
        }

        public void Create(Client item)
        {
            Sales.Model.Models.Client client = _context.Clients.FirstOrDefault(x => x.ID == item.ID);
            if (client == null)
                _context.Clients.Add(item);
        }

        public void Update(Client item)
        {
            Sales.Model.Models.Client client = _context.Clients.FirstOrDefault(x => x.ID == item.ID);
            if (client != null)
            {
                client.Name = item.Name;
                _context.Entry<Client>(client).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Client client = _context.Clients.FirstOrDefault(x => x.ID == id);
            if (client != null)
                _context.Clients.Remove(client);
        }
    }
}
