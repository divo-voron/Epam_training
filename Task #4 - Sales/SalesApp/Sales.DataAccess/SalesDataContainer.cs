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
            DataMapper = new DAMapper();
        }

        public DAMapper DataMapper { get; set; }

        public IEnumerable<Client> Clients
        {
            get { foreach (var client in _salesContext.Clients) yield return DataMapper.Mapping(client); }
        }
        public IEnumerable<Manager> Managers
        {
            get { foreach (var manager in _salesContext.Managers) yield return DataMapper.Mapping(manager); }
        }
        public IEnumerable<Product> Products
        {
            get { foreach (var product in _salesContext.Products) yield return DataMapper.Mapping(product); }
        }
        public IEnumerable<Session> Sessions
        {
            get { foreach (var session in _salesContext.Sessions) yield return DataMapper.Mapping(session); }
        }
        public IEnumerable<Operation> Operations
        {
            get { foreach (var operation in _salesContext.Operations) yield return ToObject(operation); }
        }

        public void AddClient(Client client)
        {
            _salesContext.Clients.Add(ToEntity(client));
            _salesContext.SaveChanges();
        }
        public void AddManager(Manager manager)
        {
            _salesContext.Managers.Add(ToEntity(manager));
            _salesContext.SaveChanges();
        }
        public void AddProduct(Product product)
        {
            _salesContext.Products.Add(ToEntity(product));
            _salesContext.SaveChanges();
        }
        public void AddSession(Session session)
        {
            _salesContext.Sessions.Add(ToEntity(session));
            _salesContext.SaveChanges();
        }
        public void AddOperation(Operation operation)
        {
            _salesContext.Operations.Add(ToEntity(operation));
            _salesContext.SaveChanges();
        }
        public void AddOperation(DateTime date, Manager manager, string clientName, string productName, Session session, int price)
        {
            DAL.Client client = _salesContext.Clients.FirstOrDefault(x => x.Name == clientName);
            DAL.Product product = _salesContext.Products.FirstOrDefault(x => x.Name == productName);

            if (client == null) client = new DAL.Client() { Name = clientName };
            if (product == null) product = new DAL.Product() { Name = productName };

            DAL.Operation operation = new DAL.Operation()
            {
                DateOfOperation = date,
                Manager = ToEntity(manager),
                Client = client,
                Product = product,
                Session = ToEntity(session),
                Price = price
            };

            _salesContext.Operations.Add(operation);
            _salesContext.SaveChanges();
        }

        private Operation ToObject(DAL.Operation operation)
        {
            return new Operation(operation.ID, operation.DateOfOperation, DataMapper.Mapping(operation.Manager),
                DataMapper.Mapping(operation.Client), DataMapper.Mapping(operation.Product),
                DataMapper.Mapping(operation.Session), operation.Price);
        }

        private DAL.Client ToEntity(Client client)
        {
            DAL.Client clientDAL = _salesContext.Clients.FirstOrDefault(x => x.Name == client.Name);
            if (clientDAL != null) return clientDAL;
            else
                return DataMapper.Mapping(client);
        }
        private DAL.Manager ToEntity(Manager manager)
        {
            DAL.Manager managerDAL = _salesContext.Managers.FirstOrDefault(x => x.Name == manager.Name);
            if (managerDAL != null) return managerDAL;
            else
                return DataMapper.Mapping(manager);
        }
        private DAL.Product ToEntity(Product product)
        {
            DAL.Product productDAL = _salesContext.Products.FirstOrDefault(x => x.Name == product.Name);
            if (productDAL != null) return productDAL;
            else
                return DataMapper.Mapping(product);
        }
        private DAL.Session ToEntity(Session session)
        {
            DAL.Session sessionDAL = _salesContext.Sessions.FirstOrDefault(x => x.Name == session.Name);
            if (sessionDAL != null) return sessionDAL;
            else
                return DataMapper.Mapping(session);
        }
        private DAL.Operation ToEntity(Operation operation)
        {
            DAL.Operation operationDAL = operation.Id != 0 ? _salesContext.Operations.FirstOrDefault(x => x.ID == operation.Id) : null;
            if (operationDAL != null) return operationDAL;
            else
                return new DAL.Operation()
                {
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
