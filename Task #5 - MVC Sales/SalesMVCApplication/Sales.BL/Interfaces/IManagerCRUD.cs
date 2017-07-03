using Sales.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Interfaces
{
    public interface IManagerCRUD
    {
        IEnumerable<ManagerDto> Managers { get; }
        IEnumerable<ManagerDto> GetManagerPerPage(int pageSize, int pageNumber);
        void AddManager(ManagerDto manager);
        void EditManager(ManagerDto manager);
        void DeleteManager(int id);
    }
}
