namespace WebUI.DataTransferObjects.NotificationDtos
{
    public class ResultNotificationDto
    {
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string Description { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool Status { get; set; }
    }
}
