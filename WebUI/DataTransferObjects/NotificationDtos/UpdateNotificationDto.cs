namespace WebUI.DataTransferObjects.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
