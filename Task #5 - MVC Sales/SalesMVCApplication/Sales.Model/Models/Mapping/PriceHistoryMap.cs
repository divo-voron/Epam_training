using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sales.Model.Models.Mapping
{
    public class PriceHistoryMap : EntityTypeConfiguration<PriceHistory>
    {
        public PriceHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PriceHistory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Price).HasColumnName("Price");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.PriceHistories)
                .HasForeignKey(d => d.Product_ID);

        }
    }
}
