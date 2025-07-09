using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataTransferObject.BasketDTO
{
  public  class CreateBasketDto
    {
        public int BasketId { get; set; }
        public int Count { get; set; } = 1;
        public decimal TotalPrice { get; set; }
        public int FoodId { get; set; }
      
    }
}
