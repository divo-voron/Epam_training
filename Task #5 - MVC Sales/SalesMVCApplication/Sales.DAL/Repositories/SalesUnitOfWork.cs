using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class SalesUnitOfWork : ISalesUnitOfWork
    {
        private Sales.Model.Models.SalesDataBaseContext _context;
        private IRepository<Client> clientRepo;
        private IRepository<Manager> managerRepo;
        private IRepository<Operation> operationRepo;
        private IRepository<PriceHistory> priceHistoryRepo;
        private IRepository<Product> productRepo;

        public SalesUnitOfWork(string connectionString)
        {
            _context = new Sales.Model.Models.SalesDataBaseContext(connectionString);
            clientRepo = new ClientRepository(_context);
            managerRepo = new ManagerRepository(_context);
            operationRepo = new OperationRepository(_context);
            priceHistoryRepo = new PriceHistoryRepository(_context);
            productRepo = new ProductRepository(_context);
        }



        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing) _context.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
