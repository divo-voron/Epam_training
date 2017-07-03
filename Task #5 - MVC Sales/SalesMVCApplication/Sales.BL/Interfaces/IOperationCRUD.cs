using Sales.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Interfaces
{
    public interface IOperationCRUD
    {
        IEnumerable<OperationDto> Operations { get; }
        IEnumerable<OperationDto> GetOperationPerPage(int pageSize, int pageNumber);
        IEnumerable<OperationDto> GetOperationPerPage(int pageSize, int pageNumber, int? client, int? manager, int? product);
        void AddOperation(OperationDto operation);
        void EditOperation(OperationDto operation);
        void DeleteOperation(int id);
    }
}
