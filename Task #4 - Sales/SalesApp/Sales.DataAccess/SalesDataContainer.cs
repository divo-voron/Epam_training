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
        public IEnumerable<Operation> Operations
        {
            get
            {
                foreach (var operation in _salesContext.Operations) yield return ToObject(operation);
            }
        }

        public void AddClient(string name)
        {
            DAL.Client client = _salesContext.Clients.FirstOrDefault(x => x.Name == name);
            if (client == null)
                _salesContext.Clients.Add(new DAL.Client() { Name = name });
        }
        public void AddOperation(Operation op)
        {
            _salesContext.Operations.Add(ToEntity(op));
        }
        public void AddOperation(DateTime date, string managerName, string clientName, string productName, int sessionName, int price)
        {
            DAL.Manager manager = _salesContext.Managers.FirstOrDefault(x => x.Name == managerName);
            DAL.Client client = _salesContext.Clients.FirstOrDefault(x => x.Name == clientName);
            DAL.Product product = _salesContext.Products.FirstOrDefault(x => x.Name == productName);
            DAL.Session session = _salesContext.Sessions.FirstOrDefault(x => x.Name == sessionName);

            if (manager == null) manager = new DAL.Manager() { Name = managerName };
            if (client == null) client = new DAL.Client() { Name = clientName };
            if (product == null) product = new DAL.Product() { Name = productName };
            if (session == null) session = new DAL.Session() { Name = sessionName };

            DAL.Operation operation = new DAL.Operation()
            {
                DateOfOperation = date,
                Manager = manager,
                Client = client,
                Product = product,
                Session = session,
                Price = price
            };

            _salesContext.Operations.Add(operation);
            _salesContext.SaveChanges();
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
            return new Session(session.ID, session.Date, session.Name);
        }
        private Operation ToObject(DAL.Operation operation)
        {
            return new Operation(operation.ID, operation.DateOfOperation, ToObject(operation.Manager),
                ToObject(operation.Client), ToObject(operation.Product), ToObject(operation.Session), operation.Price);
        }

        private DAL.Client ToEntity(Client client)
        {
            DAL.Client clientDAL = _salesContext.Clients.FirstOrDefault(x => x.ID == client.Id);
            if (clientDAL != null) return clientDAL;
            else
                return new DAL.Client()
                {
                    ID = client.Id,
                    Name = client.Name
                };
        }
        private DAL.Manager ToEntity(Manager manager)
        {
            DAL.Manager productDAL = _salesContext.Managers.FirstOrDefault(x => x.ID == manager.Id);
            if (productDAL != null) return productDAL;
            else
                return new DAL.Manager()
                {
                    ID = manager.Id,
                    Name = manager.Name
                };
        }
        private DAL.Product ToEntity(Product product)
        {
            DAL.Product productDAL = _salesContext.Products.FirstOrDefault(x => x.ID == product.Id);
            if (productDAL != null) return productDAL;
            else
                return new DAL.Product()
                {
                    ID = product.Id,
                    Name = product.Name
                };
        }
        private DAL.Session ToEntity(Session session)
        {
            DAL.Session sessionDAL = _salesContext.Sessions.FirstOrDefault(x => x.ID == session.Id);
            if (sessionDAL != null) return sessionDAL;
            else
                return new DAL.Session()
                {
                    ID = session.Id,
                    Date = session.DateOfOperation,
                    Name = session.Name
                };
        }


        private DAL.Operation ToEntity(Operation operation)
        {
            return new DAL.Operation()
            {
                ID = operation.Id,
                Client = ToEntity(operation.Client),
                Manager = ToEntity(operation.Manager),
                Product = ToEntity(operation.Product),
                Price = operation.Price,
                DateOfOperation = operation.DateOfOperation,
                Session = ToEntity(operation.Session)
            };
        }
    }
}
