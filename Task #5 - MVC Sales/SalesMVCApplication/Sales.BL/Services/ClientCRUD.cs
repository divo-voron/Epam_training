using Sales.BL.DTO;
using Sales.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Services
{
    public class ClientCRUD : IClientCRUD
    {
        Sales.DAL.Interfaces.ISalesUnitOfWork unit;
        BLMapper Mapper;

        public ClientCRUD(Sales.DAL.Interfaces.ISalesUnitOfWork uow)
        {
            unit = uow;
            Mapper = new BLMapper();
        }
        public IEnumerable<ClientDto> Clients
        {
            get { return unit.Clients.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ClientDto> GetClientPerPage(int pageSize, int pageNumber)
        {
            if (unit.Clients.Count() >= (pageNumber - 1) * pageSize)
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
    }
}
