using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class PriceHistoryRepository : IRepository<PriceHistory>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public PriceHistoryRepository(Sales.Model.Models.SalesDataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<PriceHistory> GetAll()
        {
            return _context.PriceHistories;
        }

        public PriceHistory Get(int id)
        {
            return _context.PriceHistories.Find(id);
        }

        public void Create(PriceHistory item)
        {
            Sales.Model.Models.PriceHistory priceHistory = _context.PriceHistories.Find(item.ID);
            if (priceHistory == null)
                _context.PriceHistories.Add(item);
        }

        public void Update(PriceHistory item)
        {
            Sales.Model.Models.PriceHistory priceHistory = _context.PriceHistories.Find(item.ID);
            if (priceHistory != null)
            {
                priceHistory.Date = item.Date;
                priceHistory.Price = item.Price;
                priceHistory.Product_ID = item.Product_ID;
                _context.Entry<PriceHistory>(priceHistory).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.PriceHistory priceHistory = _context.PriceHistories.Find(id);
            if (priceHistory != null)
                _context.PriceHistories.Remove(priceHistory);
        }
    }
}
