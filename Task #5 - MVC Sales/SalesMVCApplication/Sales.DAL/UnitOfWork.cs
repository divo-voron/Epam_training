using Sales.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL
{
    public class UnitOfWork : IDisposable
    {
        private Sales.Model.Models.SalesDataBaseContext _context = new Sales.Model.Models.SalesDataBaseContext();
        private ClientRepository clientRepo;
        private ManagerRepository managerRepo;
        private OperationRepository operationRepo;
        private PriceHistoryRepository priceHistoryRepo;
        private ProductRepository productRepo;
        private SessionRepository sessionRepo;

        public ClientRepository Clients
        {
            get
            {
                if (clientRepo == null)
                    clientRepo = new ClientRepository(_context);
                return clientRepo;
            }
        }
        public ManagerRepository Managers
        {
            get
            {
                if (managerRepo == null)
                    managerRepo = new ManagerRepository(_context);
                return managerRepo;
            }
        }
        public OperationRepository Operations
        {
            get
            {
                if (operationRepo == null)
                    operationRepo = new OperationRepository(_context);
                return operationRepo;
            }
        }
        public PriceHistoryRepository PriceHistories
        {
            get
            {
                if (priceHistoryRepo == null)
                    priceHistoryRepo = new PriceHistoryRepository(_context);
                return priceHistoryRepo;
            }
        }
        public ProductRepository Products
        {
            get
            {
                if (productRepo == null)
                    productRepo = new ProductRepository(_context);
                return productRepo;
            }
        }
        public SessionRepository Sessions
        {
            get
            {
                if (sessionRepo == null)
                    sessionRepo = new SessionRepository(_context);
                return sessionRepo;
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
                if (disposing)
                {
                    _context.Dispose();
                }
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
