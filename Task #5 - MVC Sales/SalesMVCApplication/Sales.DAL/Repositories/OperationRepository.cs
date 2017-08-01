using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class OperationRepository : AbstractRepository<Operation>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public OperationRepository(Sales.Model.Models.SalesDataBaseContext context) :
            base(context)
        {
            _context = context;
        }

        public override void Create(Operation item)
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
                    throw new ArgumentException("Can not add an operation to the database");
            }
            else
                throw new ArgumentException("Operation with this ID already exists");
        }

        public override void Update(Operation item)
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
                    throw new ArgumentException("Unable to update operation in database");
            }
            else
                throw new ArgumentException("Operation with this ID not found");
        }
    }
}
