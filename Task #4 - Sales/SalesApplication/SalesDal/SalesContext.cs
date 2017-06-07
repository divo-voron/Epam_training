namespace SalesDal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesModel")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<OperationsBuffer> OperationsBuffers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.OperationsBuffers)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.Client_ID);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Operations)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.Client_ID);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.OperationsBuffers)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.Manager_ID);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Operations)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.Manager_ID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Operations)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_ID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OperationsBuffers)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_ID);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.Operations)
                .WithOptional(e => e.Session)
                .HasForeignKey(e => e.Session_ID);
        }
    }
}
