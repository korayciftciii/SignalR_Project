using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.MoneyCaseDTO
{
  public  class CreateMoneyCaseDto
    {
        public decimal TotalAmount { get; set; } = 0;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
