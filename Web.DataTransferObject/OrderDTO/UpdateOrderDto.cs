using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.OrderDetailDTO;

namespace Web.DataTransferObject.OrderDTO
{
 public   class UpdateOrderDto
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public List<UpdateOrderDetailDto> OrderDetails { get; set; }
    }
}
