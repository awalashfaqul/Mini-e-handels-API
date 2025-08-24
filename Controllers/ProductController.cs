using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Controllers
{

    [ApiController] 
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAllProducts();

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
            return Ok (new { message = "Product added successfully."});
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok (new { message = "Product deleted successfully."});
        }

    }
}