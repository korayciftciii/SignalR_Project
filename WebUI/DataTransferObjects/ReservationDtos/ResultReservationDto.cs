﻿namespace WebUI.DataTransferObjects.ReservationDtos
{
    public class ResultReservationDto
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string UserMail { get; set; } = null!;
        public int NumberOfCustomer { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
