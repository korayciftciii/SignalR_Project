using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.SocialLinkDtos
{
    public class CreateSocialLinkDto
    {
        [Required(ErrorMessage = "Platform name is required.")]
        [StringLength(50, ErrorMessage = "Platform name cannot exceed 50 characters.")]
        public string PlatformName { get; set; } = null!;

        [Required(ErrorMessage = "URL is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Url { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Icon class cannot exceed 100 characters.")]
        public string? IconClass { get; set; }
    }
}
