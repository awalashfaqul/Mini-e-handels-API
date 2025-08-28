using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Data.Repositories.IRepositories;

namespace Mini_e_handels_API.Data.Repositories
{
    public class InMemoryCategoryRepository : ICategoryRepository     
    {
        private readonly List<Category> _categories = new();

        public IEnumerable<Category> GetAllCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void AddCategory(Category category)
        {
            category.Id = _categories.Count + 1;
            _categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = GetCategoryById(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                // Update other properties as needed
            }
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}