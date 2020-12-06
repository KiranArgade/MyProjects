using Inventory.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Inventory.Data
{
    public class InventoryEntities : DbContext
    {
        public InventoryEntities() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryEntities, Migrations.Configuration>());
        }
        public DbSet<Product> Products { get; set; }

        public virtual void Commit()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Product && (e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((Product)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
                else
                {
                    var entityProperty = entityEntry.Property("CreatedDate");
                    entityProperty.IsModified = false;
                }
            }

            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}