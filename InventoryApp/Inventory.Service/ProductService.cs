using Inventory.Data.Infrastructure;
using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Service
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void CreateProduct(Product product)
        {
            unitOfWork.ProductRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            unitOfWork.ProductRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            unitOfWork.ProductRepository.Delete(GetProduct(id));
        }

        public Product GetProduct(int id)
        {
            return unitOfWork.ProductRepository.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return unitOfWork.ProductRepository.GetAll();
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }
    }
}
