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
    public class ManagerCRUD:IManagerCRUD
    {
        Sales.DAL.Interfaces.ISalesUnitOfWork unit;
        BLMapper Mapper;

        public ManagerCRUD(Sales.DAL.Interfaces.ISalesUnitOfWork uow)
        {
            unit = uow;
            Mapper = new BLMapper();
        }
        public IEnumerable<ManagerDto> Managers
        {
            get { return unit.Managers.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ManagerDto> GetManagerPerPage(int pageSize, int pageNumber)
        {
            if (unit.Managers.Count() >= (pageNumber - 1) * pageSize)
                return unit.Managers.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new MyInvalidOperationException("End of Managers");
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
    }
}
