using CategoryAPI.Models;

namespace CategoryAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private static readonly List<Category> _categories;
        private static int _nextId = 4;

        static CategoryService()
        {
            _categories = new List<Category>
            {
                new Category 
                { 
                    Id = 1, 
                    Name = "Electronics", 
                    Description = "Electronic devices and gadgets", 
                    IsActive = true, 
                    CreatedAt = DateTime.UtcNow.AddDays(-10) 
                },
                new Category 
                { 
                    Id = 2, 
                    Name = "Books", 
                    Description = "Books and reading materials", 
                    IsActive = true, 
                    CreatedAt = DateTime.UtcNow.AddDays(-8) 
                },
                new Category 
                { 
                    Id = 3, 
                    Name = "Clothing", 
                    Description = "Clothes and fashion items", 
                    IsActive = true, 
                    CreatedAt = DateTime.UtcNow.AddDays(-5) 
                }
            };
        }

        public List<Category> GetAllCategories()
        {
            return _categories;
        }

        public Category? GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public Category CreateCategory(Category category)
        {
            category.Id = _nextId++;
            category.CreatedAt = DateTime.UtcNow;
            _categories.Add(category);
            return category;
        }

        public Category? UpdateCategory(int id, Category category)
        {
            var existingCategory = GetCategoryById(id);
            if (existingCategory == null)
                return null;

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.IsActive = category.IsActive;
            
            return existingCategory;
        }

        public bool DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category == null)
                return false;

            return _categories.Remove(category);
        }
    }
}