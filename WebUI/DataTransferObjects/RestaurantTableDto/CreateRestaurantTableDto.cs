using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.RestaurantTableDto
{
    public class CreateRestaurantTableDto
    {
        [Required(ErrorMessage = "Table number is required.")]
        [StringLength(20, ErrorMessage = "Table number cannot exceed 20 characters.")]
        public string TableNumber { get; set; } = null!;

        [Range(1, 50, ErrorMessage = "Capacity must be between 1 and 50.")]
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }
    }
}
