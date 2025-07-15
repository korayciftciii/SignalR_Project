using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.FooterContentDtos
{
    public class UpdateFooterContentDto
    {
        public int FooterContentId { get; set; }

        [Required(ErrorMessage = "Location label is required.")]
        [StringLength(100, ErrorMessage = "Location label cannot exceed 100 characters.")]
        public string? LocationLabel { get; set; }

        [Required(ErrorMessage = "Location URL is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? LocationUrl { get; set; }

        [Required(ErrorMessage = "Store number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string? StoreNumber { get; set; }

        [Required(ErrorMessage = "Store email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? StoreMail { get; set; }

        [Required(ErrorMessage = "Footer title is required.")]
        [StringLength(100, ErrorMessage = "Footer title cannot exceed 100 characters.")]
        public string? FooterTitle { get; set; }

        [Required(ErrorMessage = "Footer description is required.")]
        [StringLength(500, ErrorMessage = "Footer description cannot exceed 500 characters.")]
        public string? FooterDescription { get; set; }
    }
}
