using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IEnumerable<Category> GetAllCategories() => _categoryRepository.GetAllCategories();

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
            return Ok(new { message = "Category added successfully." });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var existingCategory = _categoryRepository.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            _categoryRepository.UpdateCategory(category);
            return Ok(new { message = "Category updated successfully." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok(new { message = "Category deleted successfully." });
        }
    }
}