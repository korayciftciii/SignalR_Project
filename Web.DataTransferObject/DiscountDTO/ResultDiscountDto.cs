using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.DiscountDTO
{
  public  class ResultDiscountDto
    {
        public int DiscountId { get; set; }
        public string DiscountTitle { get; set; } = null!;
        public string? Description { get; set; }
        public int PercentageOfDiscount { get; set; }
        public string? ImageUrl { get; set; }
        public bool DiscountStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
