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

        public IEnumerable<Manager> Managers
        {
            get
            {
                return unit.Managers.GetAll().Select(x => Mapper.Mapping(x));
            }
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
        public IEnumerable<Operation> Operations
        {
            get
            {
                return unit.Operations.GetAll().Select(x => Mapper.Mapping(x));
            }
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


        public IEnumerable<Client> Clients
        {
            get
            {
                return unit.Clients.GetAll().Select(x => Mapper.Mapping(x));
            }
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return unit.Products.GetAll().Select(x => Mapper.Mapping(x));
            }
        }
        public IEnumerable<Session> Sessions
        {
            get
            {
                return unit.Sessions.GetAll().Select(x => Mapper.Mapping(x));
            }
        }

        public IEnumerable<PriceHistory> PriceHistories
        {
            get
            {
                return unit.PriceHistories.GetAll().Select(x => Mapper.Mapping(x));
            }
        }
    }
}
