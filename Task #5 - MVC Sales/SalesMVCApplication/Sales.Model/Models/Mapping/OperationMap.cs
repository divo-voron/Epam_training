using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sales.Model.Models.Mapping
{
    public class OperationMap : EntityTypeConfiguration<Operation>
    {
        public OperationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Operations");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DateOfOperation).HasColumnName("DateOfOperation");
            this.Property(t => t.Manager_ID).HasColumnName("Manager_ID");
            this.Property(t => t.Client_ID).HasColumnName("Client_ID");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.PriceHistory_ID).HasColumnName("PriceHistory_ID");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.Operations)
                .HasForeignKey(d => d.Client_ID);
            this.HasRequired(t => t.Manager)
                .WithMany(t => t.Operations)
                .HasForeignKey(d => d.Manager_ID);
            this.HasRequired(t => t.PriceHistory)
                .WithMany(t => t.Operations)
                .HasForeignKey(d => d.PriceHistory_ID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Operations)
                .HasForeignKey(d => d.Product_ID);
        }
    }
}
