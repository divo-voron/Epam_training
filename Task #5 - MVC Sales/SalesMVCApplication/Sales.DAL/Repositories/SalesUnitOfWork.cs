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
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepo == null) clientRepo = new ClientRepository(_context);
                return clientRepo;
            }
        }
        public IRepository<Manager> Managers
        {
            get
            {
                if (managerRepo == null) managerRepo = new ManagerRepository(_context);
                return managerRepo;
            }
        }
        public IRepository<Operation> Operations
        {
            get
            {
                if (operationRepo == null) operationRepo = new OperationRepository(_context);
                return operationRepo;
            }
        }
        public IRepository<PriceHistory> PriceHistories
        {
            get
            {
                if (priceHistoryRepo == null) priceHistoryRepo = new PriceHistoryRepository(_context);
                return priceHistoryRepo;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepo == null) productRepo = new ProductRepository(_context);
                return productRepo;
            }
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
