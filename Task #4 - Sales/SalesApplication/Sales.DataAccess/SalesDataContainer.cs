using Sales.DataAccess.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess
{
    class SalesDataContainer
    {
        private SalesDal.SalesContext _salesContext;

        public SalesDataContainer() 
        {
            _salesContext = new SalesDal.SalesContext();
        }

        public IEnumerable<Client> Clients
        {
            get 
            { 
                foreach (var client in _salesContext.Clients) yield return ToObject(client); 
            }
        }
        public IEnumerable<Manager> Managers
        {
            get
            {
                foreach (var manager in _salesContext.Managers) yield return ToObject(manager);
            }
        }
        public IEnumerable<Product> Products
        {
            get
            {
                foreach (var product in _salesContext.Products) yield return ToObject(product);
            }
        }
        public IEnumerable<Session> Sessions
        {
            get
            {
                foreach (var session in _salesContext.Sessions) yield return ToObject(session);
            }
        }

        private Client ToObject(SalesDal.Client client)
        {
            return new Client(client.ID, client.Name);
        }
        private Manager ToObject(SalesDal.Manager manager)
        {
            return new Manager(manager.ID, manager.Name);
        }
        private Product ToObject(SalesDal.Product product)
        {
            return new Product(product.ID, product.Name);
        }
        private Session ToObject(SalesDal.Session session)
        {
            return new Session(session.Date, session.Name);
        }


        private SalesDal.Client ToEntity(Client client)
        {
           return new SalesDal.Client() { Name = client.Name };
        }
        private SalesDal.Manager ToEntity(Manager manager)
        {
           return new SalesDal.Manager() { Name = manager.Name };
        }
        private SalesDal.Product ToEntity(Product product)
        {
           return new SalesDal.Product() { Name = product.Name };
        }
        private SalesDal.Session ToEntity(Session session)
        {
            return new SalesDal.Session() { Date = session.DateOfOperation, Name = session.Name };
        }
    }
}
