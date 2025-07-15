using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.NotificationDtos
{
    public class CreateNotificationDto
    {
        [Required(ErrorMessage = "Notification type is required.")]
        [StringLength(50, ErrorMessage = "Notification type cannot exceed 50 characters.")]
        public string NotificationType { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = null!;

        public bool Status { get; set; }
    }
}
