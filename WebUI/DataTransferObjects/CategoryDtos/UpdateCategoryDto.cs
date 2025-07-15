using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = null!;
        public bool CategoryStatus { get; set; }
    }
}
