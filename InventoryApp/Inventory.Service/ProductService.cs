using Inventory.Data.Infrastructure;
using Inventory.Models;
using ProductReview.Data.Repositories;
using System.Collections.Generic;

namespace Inventory.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateProduct(Product product)
        {
            productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            productRepository.Delete(GetProduct(id));
        }

        public Product GetProduct(int id)
        {
            return productRepository.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }
    }
}
