using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Sales.Model.Models.Mapping;

namespace Sales.Model.Models
{
    public partial class SalesDataBaseContext : DbContext
    {
        static SalesDataBaseContext()
        {
            Database.SetInitializer<SalesDataBaseContext>(null);
        }

        public SalesDataBaseContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ManagerMap());
            modelBuilder.Configurations.Add(new OperationMap());
            modelBuilder.Configurations.Add(new PriceHistoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
