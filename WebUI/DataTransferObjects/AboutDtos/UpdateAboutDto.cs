using System.ComponentModel.DataAnnotations;

namespace WebUI.DataTransferObjects.AboutDtos
{
    public class UpdateAboutDto
    {
        public int AboutId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }
    }
}
