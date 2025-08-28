using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories.IRepositories
{
    public interface IProductRepository
    {
        // Interface for product repository
        // This interface defines the methods for managing products in the e-commerce API
        IEnumerable<Product> GetAllProducts(); // Retrieve all products
        Product GetProductById(int id); // Retrieve a product by its ID
        void AddProduct(Product product); // Add a new product
        //void UpdateProduct(Product product); // Update an existing product
        void DeleteProduct(int id); // Delete a product by its ID
        IEnumerable<Product> GetByCategory(int categoryId); // Retrieve all products belonging to a specific category
    }
}