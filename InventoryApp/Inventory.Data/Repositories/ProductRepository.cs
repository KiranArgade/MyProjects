using Inventory.Models;
using ProductReview.Data.Infrastructure;

namespace ProductReview.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}
