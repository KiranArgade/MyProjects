using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void SaveProduct();
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}