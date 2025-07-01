using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.ReservationDTO
{
  public  class UpdateReservationDto
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string UserMail { get; set; } = null!;
        public int NumberOfCustomer { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
