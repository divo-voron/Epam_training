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

        public Handler()
        {
            Mapper = new BLMapper();
        }

        public void Connect(string connectionString)
        {
            unit = new Sales.DAL.Repositories.SalesUnitOfWork(connectionString);
        }

        #region Client CRUD
        public IEnumerable<ClientDto> Clients
        {
            get { return unit.Clients.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ClientDto> GetClientPerPage(int pageSize, int pageNumber)
        {
            if (unit.Managers.Count() > (pageNumber - 1) * pageSize)
                return unit.Clients.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new IndexOutOfRangeException("End of Clients");
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
        public void DeleteClient(int id)
        {
            unit.Clients.Delete(id);
            unit.Save();
        }
        #endregion

        #region Manager CRUD
        public IEnumerable<ManagerDto> Managers
        {
            get { return unit.Managers.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ManagerDto> GetManagerPerPage(int pageSize, int pageNumber)
        {
            if (unit.Managers.Count() > (pageNumber - 1) * pageSize)
                return unit.Managers.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new IndexOutOfRangeException("End of Managers");
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
        public void DeleteManager(int id)
        {
            unit.Managers.Delete(id);
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
            if (unit.Managers.Count() > (pageNumber - 1) * pageSize)
                return unit.Operations.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else 
                throw new IndexOutOfRangeException("End of Operations");
        }
        public IEnumerable<OperationDto> GetOperationPerPage(int pageSize, int pageNumber, int? client, int? manager, int? product)
        {
            var result = unit.Operations.GetAll()
                            .Where(x => (client != null ? x.Client_ID == client : true) &&
                                        (manager != null ? x.Manager_ID == manager : true) &&
                                        (product != null ? x.Product_ID == product : true));
            if (result.Count() >= (pageNumber - 1) * pageSize)
                return result.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new IndexOutOfRangeException("End of Operations");
            
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
        public void DeleteOperation(int id)
        {
            unit.Operations.Delete(id);
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
            if (unit.Managers.Count() > (pageNumber - 1) * pageSize)
                return unit.Products.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new IndexOutOfRangeException("End of Products");
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
        public void DeleteProduct(int id)
        {
            unit.Products.Delete(id);
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
            if (unit.Managers.Count() > (pageNumber - 1) * pageSize)
                return unit.PriceHistories.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new IndexOutOfRangeException("End of PriceHistories");
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
        public void DeletePriceHistory(int id)
        {
            unit.PriceHistories.Delete(id);
            unit.Save();
        }
        #endregion
    }
}
