using Sales.Model.Models;
using System;
namespace Sales.DAL.Interfaces
{
    public interface ISalesUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }
        void Dispose();
        void Dispose(bool disposing);
        IRepository<Manager> Managers { get; }
        IRepository<Operation> Operations { get; }
        IRepository<PriceHistory> PriceHistories { get; }
        IRepository<Product> Products { get; }
        void Save();
    }
}
