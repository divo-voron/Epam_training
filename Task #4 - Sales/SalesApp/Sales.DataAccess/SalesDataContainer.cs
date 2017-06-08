using Sales.DataAccess.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess
{
    public class SalesDataContainer
    {
        private DAL.SalesContext _salesContext;

        public SalesDataContainer() 
        {
            _salesContext = new DAL.SalesContext();
        }

        public IEnumerable<IClient> Clients
        {
            get 
            { 
                foreach (var client in _salesContext.Clients) yield return ToObject(client); 
            }
        }
        public IEnumerable<IManager> Managers
        {
            get
            {
                foreach (var manager in _salesContext.Managers) yield return ToObject(manager);
            }
        }
        public IEnumerable<IProduct> Products
        {
            get
            {
                foreach (var product in _salesContext.Products) yield return ToObject(product);
            }
        }
        public IEnumerable<ISession> Sessions
        {
            get
            {
                foreach (var session in _salesContext.Sessions) yield return ToObject(session);
            }
        }

        public void AddClient(string name)
        {
            _salesContext.Clients.Add(new DAL.Client() { Name = name });
        }
        public void Save()
        {
            _salesContext.SaveChanges();
        }

        private Client ToObject(DAL.Client client)
        {
            return new Client(client.ID, client.Name);
        }
        private Manager ToObject(DAL.Manager manager)
        {
            return new Manager(manager.ID, manager.Name);
        }
        private Product ToObject(DAL.Product product)
        {
            return new Product(product.ID, product.Name);
        }
        private Session ToObject(DAL.Session session)
        {
            return new Session(session.Date, session.Name);
        }


        private DAL.Client ToEntity(Client client)
        {
            return new DAL.Client() { Name = client.Name };
        }
        private DAL.Manager ToEntity(Manager manager)
        {
            return new DAL.Manager() { Name = manager.Name };
        }
        private DAL.Product ToEntity(Product product)
        {
            return new DAL.Product() { Name = product.Name };
        }
        private DAL.Session ToEntity(Session session)
        {
            return new DAL.Session() { Date = session.DateOfOperation, Name = session.Name };
        }
    }
}
