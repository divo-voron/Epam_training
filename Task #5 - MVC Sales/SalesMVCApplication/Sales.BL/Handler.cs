using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.BL.Model;

namespace Sales.BL
{
    public class Handler
    {
        Sales.DAL.UnitOfWork unit;
        BLMapper Mapper;

        public Handler()
        {
            unit = new Sales.DAL.UnitOfWork();
            Mapper = new BLMapper();
        }

        #region Manager CRUD
        public IEnumerable<Manager> Managers
        {
            get { return unit.Managers.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<Manager> GetManagerPerPage(int pageSize, int pageNumber)
        {
            return unit.Managers.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddManager(Manager manager)
        {
            unit.Managers.Create(Mapper.Mapping(manager));
            unit.Save();
        }
        public void EditManager(Manager manager)
        {
            unit.Managers.Update(Mapper.Mapping(manager));
            unit.Save();
        }
        public void DeleteManager(Manager manager)
        {
            unit.Managers.Delete(manager.ID);
            unit.Save();
        }
        #endregion

        #region Opertion CRUD
        public IEnumerable<Operation> Operations
        {
            get { return unit.Operations.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<Operation> GetOperationPerPage(int pageSize, int pageNumber)
        {
            return unit.Operations.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddOperation(Operation operation)
        {
            unit.Operations.Create(Mapper.Mapping(operation));
            unit.Save();
        }
        public void EditOperation(Operation operation)
        {
            unit.Operations.Update(Mapper.Mapping(operation));
            unit.Save();
        }
        public void DeleteOperation(Operation operation)
        {
            unit.Operations.Delete(operation.ID);
            unit.Save();
        }
        #endregion

        #region Client CRUD
        public IEnumerable<Client> Clients
        {
            get { return unit.Clients.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<Client> GetClientPerPage(int pageSize, int pageNumber)
        {
            return unit.Clients.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddClient(Client client)
        {
            unit.Clients.Create(Mapper.Mapping(client));
            unit.Save();
        }
        public void EditClient(Client client)
        {
            unit.Clients.Update(Mapper.Mapping(client));
            unit.Save();
        }
        public void DeleteOperation(Client client)
        {
            unit.Clients.Delete(client.ID);
            unit.Save();
        }
        #endregion

        #region Product CRUD
        public IEnumerable<Product> Products
        {
            get { return unit.Products.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<Product> GetProductPerPage(int pageSize, int pageNumber)
        {
            return unit.Products.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddProduct(Product product)
        {
            unit.Products.Create(Mapper.Mapping(product));
            unit.Save();
        }
        public void EditProduct(Product product)
        {
            unit.Products.Update(Mapper.Mapping(product));
            unit.Save();
        }
        public void DeleteProduct(Product product)
        {
            unit.Products.Delete(product.ID);
            unit.Save();
        }
        #endregion

        #region Session CRUD
        public IEnumerable<Session> Sessions
        {
            get { return unit.Sessions.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<Session> GetSessionPerPage(int pageSize, int pageNumber)
        {
            return unit.Sessions.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddSession(Session session)
        {
            unit.Sessions.Create(Mapper.Mapping(session));
            unit.Save();
        }
        public void EditSession(Session session)
        {
            unit.Sessions.Update(Mapper.Mapping(session));
            unit.Save();
        }
        public void DeleteSession(Session session)
        {
            unit.Sessions.Delete(session.ID);
            unit.Save();
        }
        #endregion

        #region PriceHistory CRUD
        public IEnumerable<PriceHistory> PriceHistories
        {
            get { return unit.PriceHistories.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<PriceHistory> GetPriceHistoryPerPage(int pageSize, int pageNumber)
        {
            return unit.PriceHistories.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddPriceHistory(PriceHistory priceHistory)
        {
            unit.PriceHistories.Create(Mapper.Mapping(priceHistory));
            unit.Save();
        }
        public void EditPriceHistory(PriceHistory priceHistory)
        {
            unit.PriceHistories.Update(Mapper.Mapping(priceHistory));
            unit.Save();
        }
        public void DeletePriceHistory(PriceHistory priceHistory)
        {
            unit.PriceHistories.Delete(priceHistory.ID);
            unit.Save();
        }
        #endregion
    }
}
