using AutoMapper;
using Inventory.Filters;
using Inventory.Models;
using Inventory.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Inventory.Controllers
{
    [Authorize]
    [CustomExceptionFilter]
    public class InventoryController : ApiController
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;

        public InventoryController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        // GET api/<controller>
        public IEnumerable<ProductViewModel> Get()
        {
            var prods = productService.GetProducts();
            IEnumerable<ProductViewModel> prodsToDisplay = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(prods);
            return prodsToDisplay;
        }

        // GET api/<controller>/5
        public ProductViewModel Get(int id)
        {
            Product product = productService.GetProduct(id);
            ProductViewModel prodsToDisplay = mapper.Map<Product, ProductViewModel>(product);
            return prodsToDisplay;
        }

        // POST api/<controller>
        public void Post([FromBody] ProductViewModel value)
        {
            Product product = mapper.Map<ProductViewModel, Product>(value);
            //product.CreatedDate = DateTime.Now;
            productService.CreateProduct(product);
            productService.SaveProduct();
        }

        // PUT api/<controller>/5
        public void Put([FromBody] ProductViewModel value)
        {
            Product product = mapper.Map<ProductViewModel, Product>(value);
            productService.UpdateProduct(product);
            productService.SaveProduct();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
            productService.SaveProduct();
        }
    }
}