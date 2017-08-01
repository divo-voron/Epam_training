using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class PriceHistoryRepository : AbstractRepository<PriceHistory>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public PriceHistoryRepository(Sales.Model.Models.SalesDataBaseContext context):
            base(context)
        {
            _context = context;
        }
        
        public override void Create(PriceHistory item)
        {
            Sales.Model.Models.PriceHistory priceHistory = _context.PriceHistories.Find(item.ID);
            if (priceHistory == null)
                _context.PriceHistories.Add(item);
            else
                throw new ArgumentException("PriceHistory with this ID already exists");
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
            else
                throw new ArgumentException("PriceHistory with this ID not found");
        }
    }
}
