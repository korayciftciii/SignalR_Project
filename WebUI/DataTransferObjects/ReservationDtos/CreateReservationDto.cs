using System.ComponentModel.DataAnnotations;
using WebUI.Attributes;

namespace WebUI.DataTransferObjects.ReservationDtos
{
    public class CreateReservationDto
    {
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name cannot exceed 100 characters.")]
        public string CustomerName { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string UserMail { get; set; } = null!;

        [Range(1, 100, ErrorMessage = "Number of customers must be between 1 and 100.")]
        public int NumberOfCustomer { get; set; }

        [Required(ErrorMessage = "Reservation date is required.")]
        [DataType(DataType.DateTime)]
        [FutureDate(ErrorMessage = "Reservation date must be in the future.")]
        public DateTime ReservationDate { get; set; }
    }
}
