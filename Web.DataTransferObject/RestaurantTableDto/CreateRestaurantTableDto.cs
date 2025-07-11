using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.RestaurantTableDto
{
   public class CreateRestaurantTableDto
    {
        public string RestaurantTableNumber { get; set; } 
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
