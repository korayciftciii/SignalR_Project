namespace WebUI.DataTransferObjects.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string NotificationType { get; set; }
        public string Description { get; set; }
        public DateTime NotificationDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;
    }
}
