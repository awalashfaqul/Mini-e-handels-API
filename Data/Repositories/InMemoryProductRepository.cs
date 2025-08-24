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
        private readonly List<Product> _products = new ();

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


        public IEnumerable<Product> GetAllProducts() => _products;
        //{
          //  throw new NotImplementedException();
        //}

        public Product GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);
        //{
           //   throw new NotImplementedException();
        //}
    }
}