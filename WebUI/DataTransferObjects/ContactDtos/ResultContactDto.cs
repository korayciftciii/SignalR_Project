namespace WebUI.DataTransferObjects.ContactDtos
{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime ContactDate { get; set; }
        public bool IsRead { get; set; }
    }
}
