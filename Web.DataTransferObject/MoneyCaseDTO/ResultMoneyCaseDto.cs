using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.MoneyCaseDTO
{
   public class ResultMoneyCaseDto
    {
        public int MoneyCaseId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }
}
