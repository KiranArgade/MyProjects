//using Inventory.Models;
//using System;
//using System.Data.Entity;
//using System.Data.Entity.Migrations;

//namespace Inventory.Data
//{
//    public class InventorySeedData : DbMigrationsConfiguration<InventoryEntities>
//    {
//        public InventorySeedData()
//        {
//            AutomaticMigrationsEnabled = true;
//        }
//        protected override void Seed(InventoryEntities context)
//        {
//            context.Products.AddOrUpdate(x => x.Name,
//                new Product { Name = "Keyboard", Price = 15.0m, Quantity = 10, CreatedDate = DateTime.Now },
//                new Product { Name = "Power Cord", Price = 5.00m, Quantity = 100, CreatedDate = DateTime.Now },
//                new Product { Name = "Sticker", Price = 1.0m, Quantity = 50, CreatedDate = DateTime.Now });

//            context.SaveChanges();
//        }
//    }
//}