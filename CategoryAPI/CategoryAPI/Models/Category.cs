using System.ComponentModel.DataAnnotations;

namespace CategoryAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        // TODO: Thêm [Required] và [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}