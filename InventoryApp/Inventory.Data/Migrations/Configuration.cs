using Inventory.Models;
using System;
using System.Data.Entity.Migrations;

namespace Inventory.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<InventoryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(InventoryEntities context)
        {
            context.Products.AddOrUpdate(x => new { x.Name },
                new Product { Name = "Keyboard", Price = 15.0m, Quantity = 10 },
                new Product { Name = "Power Cord", Price = 5.00m, Quantity = 100 },
                new Product { Name = "Sticker", Price = 1.0m, Quantity = 50 });

            context.Commit();
        }
    }
}