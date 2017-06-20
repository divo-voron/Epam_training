using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class OperationRepository:IRepository<Operation>
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

        public Operation Get(int id)
        {
            return _context.Operations.FirstOrDefault(x => x.ID == id);
        }

        public void Create(Operation item)
        {
            Sales.Model.Models.Operation operation = _context.Operations.FirstOrDefault(x => x.ID == item.ID);
            if (operation == null)
                _context.Operations.Add(item);
        }

        public void Update(Operation item)
        {
            Sales.Model.Models.Operation operation = _context.Operations.FirstOrDefault(x => x.ID == item.ID);
            if (operation != null)
            {
                operation.Client_ID = item.Client_ID;
                operation.DateOfOperation = item.DateOfOperation;
                operation.Manager_ID = item.Manager_ID;
                operation.PriceHistory_ID = item.PriceHistory_ID;
                operation.Product_ID = item.Product_ID;
                operation.Session_ID = item.Session_ID;
                _context.Entry<Operation>(operation).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Operation operation = _context.Operations.FirstOrDefault(x => x.ID == id);
            if (operation != null)
                _context.Operations.Remove(operation);
        }
    }
}
