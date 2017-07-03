using Sales.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Interfaces
{
    public interface IPriceHistoryCRUD
    {
        IEnumerable<PriceHistoryDto> PriceHistories { get; }
        IEnumerable<PriceHistoryDto> GetPriceHistoryPerPage(int pageSize, int pageNumber);
        void AddPriceHistory(PriceHistoryDto priceHistory);
        void EditPriceHistory(PriceHistoryDto priceHistory);
        void DeletePriceHistory(int id);
    }
}
