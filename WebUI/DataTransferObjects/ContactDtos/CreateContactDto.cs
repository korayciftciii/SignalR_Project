using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.ContactDtos
{
    public class CreateContactDto
    {

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(150, ErrorMessage = "Email address cannot exceed 150 characters.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(1000, ErrorMessage = "Subject cannot exceed 1000 characters.")]
        public string Subject { get; set; } = null!;

        public DateTime ContactDate { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;
    }
}
