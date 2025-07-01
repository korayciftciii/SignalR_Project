namespace WebUI.DataTransferObjects.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl { get; set; }
        public bool CommentStatus { get; set; }
    }
}
