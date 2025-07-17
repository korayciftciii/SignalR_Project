using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.MailDtos
{
    public class CreateMailDto
    {
        [Required(ErrorMessage = "Receiver email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Reciever { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(100, ErrorMessage = "Subject cannot be longer than 100 characters.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message body is required.")]
        [MinLength(10, ErrorMessage = "Message body must be at least 10 characters long.")]
        public string Body { get; set; }
    }
}
