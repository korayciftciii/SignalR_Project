using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }

        [Required(ErrorMessage = "Customer full name is required.")]
        [StringLength(100, ErrorMessage = "Customer full name cannot exceed 100 characters.")]
        public string CustomerFullName { get; set; } = null!;
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; } = null!;
        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
        public string? Comment { get; set; } = null!;

        [Url(ErrorMessage = "Please enter a valid image URL.")]
        public string? ImageUrl { get; set; }

        public bool CommentStatus { get; set; }
    }
}
