using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class OperationRepository : IRepository<Operation>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public OperationRepository(Sales.Model.Models.SalesDataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Operation> GetAll()
        {
            return _context.Operations;
        }
        public int Count()
        {
            return _context.Operations.Count(); 
        }
        public Operation Get(int id)
        {
            return _context.Operations.Find(id);
        }

        public void Create(Operation item)
        {
            Sales.Model.Models.Operation operation = _context.Operations.Find(item.ID);
            if (operation == null)
            {
                if (_context.Clients.Any(x => x.ID == item.Client_ID) &&
                    _context.Managers.Any(x => x.ID == item.Manager_ID) &&
                    _context.Products.Any(x => x.ID == item.Product_ID))
                {
                    item.PriceHistory.Product_ID = item.Product_ID;

                    var price = _context.PriceHistories.Where(x => x.Product_ID == item.Product_ID).ToList();
                    if (price.Count > 0 && price.Last().Price == item.PriceHistory.Price)
                        item.PriceHistory = price.Last();
                    else
                        item.PriceHistory.Date = DateTime.Now;

                    _context.Operations.Add(item);
                }
                else
                    throw new ArgumentException("Невозможно добавить запись в базу.");
            }
        }

        public void Update(Operation item)
        {
            Sales.Model.Models.Operation operation = _context.Operations.Find(item.ID);
            if (operation != null)
            {
                if (_context.Clients.Any(x => x.ID == item.Client_ID) &&
                    _context.Managers.Any(x => x.ID == item.Manager_ID) &&
                    _context.Products.Any(x => x.ID == item.Product_ID))
                {
                    var price = _context.PriceHistories.Where(x => x.Product_ID == item.Product_ID && x.Date <= item.PriceHistory.Date).ToList();
                    if (price.Count > 0 && price.Last().Price == item.PriceHistory.Price)
                        item.PriceHistory = price.Last();
                    else
                        item.PriceHistory.Date = DateTime.Now;

                    operation.Client_ID = item.Client_ID;
                    operation.DateOfOperation = item.DateOfOperation;
                    operation.Manager_ID = item.Manager_ID;

                    operation.Product_ID = item.Product_ID;
                    _context.Entry<Operation>(operation).State = System.Data.Entity.EntityState.Modified;
                }
                else
                    throw new ArgumentException("Невозможно обновить запись в базе");
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Operation operation = _context.Operations.Find(id);
            if (operation != null)
                _context.Operations.Remove(operation);
        }
    }
}
