using System.ComponentModel.DataAnnotations;
using WebUI.Attributes;

namespace WebUI.DataTransferObjects.OpeningHourDtos
{
    public class UpdateOpeningHourDto
    {
        public int OpeningHourId { get; set; }

        [Required(ErrorMessage = "Day of week is required.")]
        public DayOfWeek DayOfWeek { get; set; }

        public bool IsClosed { get; set; }

        [Display(Name = "Opening Time")]
        [RequiredIf(nameof(IsClosed), false, ErrorMessage = "Opening time is required if the business is open.")]
        public TimeSpan? OpenTime { get; set; }

        [Display(Name = "Closing Time")]
        [RequiredIf(nameof(IsClosed), false, ErrorMessage = "Closing time is required if the business is open.")]
        [TimeSpanGreaterThan(nameof(OpenTime), ErrorMessage = "Closing time must be later than opening time.")]
        public TimeSpan? CloseTime { get; set; }
    }
}
