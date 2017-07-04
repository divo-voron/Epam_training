using Sales.BL.DTO;
using Sales.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.BL.Infrastructure;

namespace Sales.BL.Services
{
    public class OperationCRUD : IOperationCRUD
    {
        Sales.DAL.Interfaces.ISalesUnitOfWork unit;
        BLMapper Mapper;

        public OperationCRUD(Sales.DAL.Interfaces.ISalesUnitOfWork uow)
        {
            unit = uow;
            Mapper = new BLMapper();
        }
        public IEnumerable<OperationDto> Operations
        {
            get { return unit.Operations.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<OperationDto> GetOperationPerPage(int pageSize, int pageNumber)
        {
            if (unit.Operations.Count() >= (pageNumber - 1) * pageSize)
                return unit.Operations.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new MyInvalidOperationException("End of Operations");
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
                throw new MyInvalidOperationException("End of Operations");
            
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
    }
}
