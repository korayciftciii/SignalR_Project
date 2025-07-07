using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
  public  interface IRestaurantTableService :IGenericService<RestaurantTable>
    {
        public int GetTableCount();
        public int GetAvaliableTableCount();
        public int GetOccupiedTableCount();
    }
}
