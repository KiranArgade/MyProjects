using Inventory.Data;
using Inventory.Models;
using ProductReview.Data.Infrastructure;

namespace ProductReview.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(InventoryEntities dbContext) : base(dbContext)
        {

        }
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}
