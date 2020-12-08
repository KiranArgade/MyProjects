using ProductReview.Data.Infrastructure;
using ProductReview.Data.Repositories;
using System.Data.Entity;

namespace Inventory.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private InventoryEntities dbContext;

        public UnitOfWork()
        {
            dbContext = new InventoryEntities();
        }

        public IProductRepository ProductRepository => new ProductRepository(dbContext);

        public void Commit()
        {
            dbContext.Commit();
        }
    }
}
