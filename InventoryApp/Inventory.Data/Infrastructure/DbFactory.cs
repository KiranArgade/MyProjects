using ProductReview.Data.Infrastructure;

namespace Inventory.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        InventoryEntities dbContext;
        public InventoryEntities Init()
        {
            return dbContext ?? (dbContext = new InventoryEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
