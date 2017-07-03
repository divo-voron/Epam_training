using Sales.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Interfaces
{
    public interface IClientCRUD
    {
        IEnumerable<ClientDto> Clients { get; }
        IEnumerable<ClientDto> GetClientPerPage(int pageSize, int pageNumber);
        void AddClient(ClientDto client);
        void EditClient(ClientDto client);
        void DeleteClient(int id);
    }
}
