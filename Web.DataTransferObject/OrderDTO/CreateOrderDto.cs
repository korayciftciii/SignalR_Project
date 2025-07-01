using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.OrderDetailDTO;
using Web.EntityLayer.Entities;

namespace Web.DataTransferObject.OrderDTO
{
  public  class CreateOrderDto
    {
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}
