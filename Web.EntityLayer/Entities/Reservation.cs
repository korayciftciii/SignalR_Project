namespace Web.EntityLayer.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string UserMail { get; set; } = null!;
        public int NumberOfCustomer { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
    }
}
