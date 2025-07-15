using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }

        [Required(ErrorMessage = "Customer full name is required.")]
        [StringLength(100, ErrorMessage = "Customer full name cannot exceed 100 characters.")]
        public string CustomerFullName { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; }

        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
        public string? Comment { get; set; }

        [Url(ErrorMessage = "Please enter a valid image URL.")]
        public string? ImageUrl { get; set; }

        public bool CommentStatus { get; set; }
    }
}
