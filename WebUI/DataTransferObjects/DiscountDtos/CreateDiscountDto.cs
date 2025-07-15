using System.ComponentModel.DataAnnotations;
using WebUI.Attributes;

namespace WebUI.DataTransferObjects.DiscountDtos
{
    public class CreateDiscountDto
    {
        [Required(ErrorMessage = "Discount title is required.")]
        [StringLength(150, ErrorMessage = "Discount title cannot exceed 150 characters.")]
        public string DiscountTitle { get; set; } = null!;
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; } = null!;

        [Range(1, 100, ErrorMessage = "Discount percentage must be between 1 and 100.")]
        public int PercentageOfDiscount { get; set; }
        [Required(ErrorMessage = "Discount image is required.")]
        [Url(ErrorMessage = "Please enter a valid image URL.")]
        public string ImageUrl { get; set; } = null!;

        public bool DiscountStatus { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "End date is required.")]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be after the start date.")]
        public DateTime EndDate { get; set; }
    }
}
