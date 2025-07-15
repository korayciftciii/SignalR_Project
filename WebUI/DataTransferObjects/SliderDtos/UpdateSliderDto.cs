using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.SliderDtos
{
    public class UpdateSliderDto
    {
        public int SliderId { get; set; }

        [Required(ErrorMessage = "Slider title is required.")]
        [StringLength(150, ErrorMessage = "Slider title cannot exceed 150 characters.")]
        public string SliderTitle { get; set; } = null!;
        [Required(ErrorMessage = "Slider Description is required.")]
        [StringLength(500, ErrorMessage = "Slider description cannot exceed 500 characters.")]
        public string? SliderDescription { get; set; } = null!;
        [Required(ErrorMessage = "Button Label is required.")]
        [StringLength(50, ErrorMessage = "Button label cannot exceed 50 characters.")]
        public string? ButtonLabel { get; set; } = null!;

        public bool FeatureStatus { get; set; }
    }
}
