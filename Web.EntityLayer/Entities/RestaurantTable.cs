using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EntityLayer.Entities
{
  public  class RestaurantTable
    {
        public int RestaurantTableId { get; set; }
        public string TableNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
