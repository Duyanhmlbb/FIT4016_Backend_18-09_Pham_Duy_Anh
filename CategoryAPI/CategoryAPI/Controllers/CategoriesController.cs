using CategoryAPI.Models;
using CategoryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        // GET: api/categories?name=electronics&page=1&pageSize=10
        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories(
            string? name = null, 
            int page = 1, 
            int pageSize = 10)
        {
            // Validate pagination parameters
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 100) pageSize = 100; // Giới hạn max

            var categories = _categoryService.GetAllCategories();
            
            // Filter by name
            if (!string.IsNullOrEmpty(name))
            {
                categories = categories
                    .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            
            // Pagination
            var paginated = categories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            return Ok(paginated);
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            
            if (category == null)
                return NotFound();
                
            return Ok(category);
        }

        // POST: api/categories
        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            var createdCategory = _categoryService.CreateCategory(category);
            
            return CreatedAtAction(
                nameof(GetCategoryById), 
                new { id = createdCategory.Id }, 
                createdCategory
            );
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public ActionResult<Category> UpdateCategory(int id, Category category)
        {
            var updatedCategory = _categoryService.UpdateCategory(id, category);
            
            if (updatedCategory == null)
                return NotFound();
                
            return Ok(updatedCategory);
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            
            if (!result)
                return NotFound();
                
            return NoContent();
        }
    }
}