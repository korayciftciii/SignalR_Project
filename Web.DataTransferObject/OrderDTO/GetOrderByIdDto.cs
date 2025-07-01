using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.OrderDetailDTO;
using Web.EntityLayer.Entities;

namespace Web.DataTransferObject.OrderDTO
{
   public class GetOrderByIdDto
    {
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCompleted { get; set; }

        public List<ResultOrderDetailDto> OrderDetails { get; set; }
    }
}
