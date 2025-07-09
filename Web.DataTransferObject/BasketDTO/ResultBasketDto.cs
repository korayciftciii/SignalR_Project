using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.BasketDTO
{
  public  class ResultBasketDto
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }

        public int FoodId { get; set; }

        public int RestaurantTableId { get; set; }
        public string TableNumber { get; set; }
        public string FoodName { get; set; }
    }
}
