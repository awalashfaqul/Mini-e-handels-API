using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        // Interface for category repository
        // This interface defines the methods for managing categories in the e-commerce API
        IEnumerable<Category> GetAllCategories(); // Retrieve all categories
        Category GetCategoryById(int id); // Retrieve a category by its ID
        void AddCategory(Category category); // Add a new category
        void UpdateCategory(Category category); // Update an existing category
        void DeleteCategory(int id); // Delete a category by its ID
    }
}