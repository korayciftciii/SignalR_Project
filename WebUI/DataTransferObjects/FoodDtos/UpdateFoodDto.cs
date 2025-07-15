using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.FoodDtos
{
    public class UpdateFoodDto
    {
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Food name is required.")]
        [StringLength(100, ErrorMessage = "Food name cannot exceed 100 characters.")]
        public string FoodName { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "Please enter a valid image URL.")]
        public string? ImageUrl { get; set; }

        public bool FoodStatus { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category.")]
        public int CategoryId { get; set; }
    }
}
