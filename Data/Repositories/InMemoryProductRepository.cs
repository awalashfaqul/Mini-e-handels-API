using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories
{

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public void AddProduct(Product product)
        {
            product.Id = _products.Count + 1; // Simple ID generation

            // Note: In a real application, ID generation will be handled more robustly,
            // such as using a database or a more sophisticated ID generation strategy.
            _products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Description = product.Description;
                
            }
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId);
        }
    }
}