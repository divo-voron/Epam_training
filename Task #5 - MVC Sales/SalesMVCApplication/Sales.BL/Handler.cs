using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.BL.DTO;

namespace Sales.BL
{
    public class Handler
    {
        Sales.DAL.Interfaces.ISalesUnitOfWork unit;
        BLMapper Mapper;

        public Handler(string connectionString)
        {
            unit = new Sales.DAL.Repositories.SalesUnitOfWork(connectionString);
            Mapper = new BLMapper();
        }

        #region Manager CRUD
        public IEnumerable<ManagerDto> Managers
        {
            get { return unit.Managers.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ManagerDto> GetManagerPerPage(int pageSize, int pageNumber)
        {
            return unit.Managers.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddManager(ManagerDto manager)
        {
            unit.Managers.Create(Mapper.Mapping(manager));
            unit.Save();
        }
        public void EditManager(ManagerDto manager)
        {
            unit.Managers.Update(Mapper.Mapping(manager));
            unit.Save();
        }
        public void DeleteManager(ManagerDto manager)
        {
            unit.Managers.Delete(manager.ID);
            unit.Save();
        }
        #endregion

        #region Opertion CRUD
        public IEnumerable<OperationDto> Operations
        {
            get { return unit.Operations.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<OperationDto> GetOperationPerPage(int pageSize, int pageNumber)
        {
            return unit.Operations.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public IEnumerable<OperationDto> GetOperationPerPage(int pageSize, int pageNumber, int? client, int? manager, int? product, int? price)
        {
            return unit.Operations.GetAll()
                .Where(x => (client != null ? x.Client_ID == client : true) &&
                            (manager != null ? x.Manager_ID == manager : true) &&
                            (product != null ? x.Product_ID == product : true) &&
                            (price != null ? x.PriceHistory_ID == price : true))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddOperation(OperationDto operation)
        {
            unit.Operations.Create(Mapper.Mapping(operation));
            unit.Save();
        }
        public void EditOperation(OperationDto operation)
        {
            unit.Operations.Update(Mapper.Mapping(operation));
            unit.Save();
        }
        public void DeleteOperation(OperationDto operation)
        {
            unit.Operations.Delete(operation.ID);
            unit.Save();
        }
        #endregion

        #region Client CRUD
        public IEnumerable<ClientDto> Clients
        {
            get { return unit.Clients.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ClientDto> GetClientPerPage(int pageSize, int pageNumber)
        {
            return unit.Clients.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddClient(ClientDto client)
        {
            unit.Clients.Create(Mapper.Mapping(client));
            unit.Save();
        }
        public void EditClient(ClientDto client)
        {
            unit.Clients.Update(Mapper.Mapping(client));
            unit.Save();
        }
        public void DeleteClient(ClientDto client)
        {
            unit.Clients.Delete(client.ID);
            unit.Save();
        }
        #endregion

        #region Product CRUD
        public IEnumerable<ProductDto> Products
        {
            get { return unit.Products.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ProductDto> GetProductPerPage(int pageSize, int pageNumber)
        {
            return unit.Products.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddProduct(ProductDto product)
        {
            unit.Products.Create(Mapper.Mapping(product));
            unit.Save();
        }
        public void EditProduct(ProductDto product)
        {
            unit.Products.Update(Mapper.Mapping(product));
            unit.Save();
        }
        public void DeleteProduct(ProductDto product)
        {
            unit.Products.Delete(product.ID);
            unit.Save();
        }
        #endregion

        #region PriceHistory CRUD
        public IEnumerable<PriceHistoryDto> PriceHistories
        {
            get { return unit.PriceHistories.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<PriceHistoryDto> GetPriceHistoryPerPage(int pageSize, int pageNumber)
        {
            return unit.PriceHistories.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
        }
        public void AddPriceHistory(PriceHistoryDto priceHistory)
        {
            unit.PriceHistories.Create(Mapper.Mapping(priceHistory));
            unit.Save();
        }
        public void EditPriceHistory(PriceHistoryDto priceHistory)
        {
            unit.PriceHistories.Update(Mapper.Mapping(priceHistory));
            unit.Save();
        }
        public void DeletePriceHistory(PriceHistoryDto priceHistory)
        {
            unit.PriceHistories.Delete(priceHistory.ID);
            unit.Save();
        }
        #endregion
    }
}
