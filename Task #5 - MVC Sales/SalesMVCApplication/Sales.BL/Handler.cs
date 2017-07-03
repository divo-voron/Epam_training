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

        public IEnumerable<ClientDto> Clients
        {
            get { return unit.Clients.GetAll().Select(x => Mapper.Mapping(x)); }
        }

        public IEnumerable<ManagerDto> Managers
        {
            get { return unit.Managers.GetAll().Select(x => Mapper.Mapping(x)); }
        }

        public IEnumerable<ProductDto> Products
        {
            get { return unit.Products.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<PriceHistoryDto> PriceHistories
        {
            get { return unit.PriceHistories.GetAll().Select(x => Mapper.Mapping(x)); }
        }
    }
}
