using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.OrderDetailDTO
{
  public  class ResultOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; } // Food.Name
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
