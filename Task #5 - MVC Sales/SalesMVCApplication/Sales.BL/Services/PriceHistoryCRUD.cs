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
    public class PriceHistoryCRUD : IPriceHistoryCRUD
    {
        Sales.DAL.Interfaces.ISalesUnitOfWork unit;
        BLMapper Mapper;

        public PriceHistoryCRUD(Sales.DAL.Interfaces.ISalesUnitOfWork uow)
        {
            unit = uow;
            Mapper = new BLMapper();
        }
        public IEnumerable<PriceHistoryDto> PriceHistories
        {
            get { return unit.PriceHistories.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<PriceHistoryDto> GetPriceHistoryPerPage(int pageSize, int pageNumber)
        {
            if (unit.PriceHistories.Count() >= (pageNumber - 1) * pageSize)
                return unit.PriceHistories.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new MyInvalidOperationException("End of PriceHistories");
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
    }
}
