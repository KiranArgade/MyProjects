using Inventory.Models;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Data
{
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Price).IsRequired().HasPrecision(16, 2);
            Property(g => g.Quantity).IsRequired();
        }
    }
}