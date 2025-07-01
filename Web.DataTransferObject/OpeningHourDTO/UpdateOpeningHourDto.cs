using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.OpeningHourDTO
{
   public class UpdateOpeningHourDto
    {
        public int OpeningHourId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsClosed { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
    }
}
