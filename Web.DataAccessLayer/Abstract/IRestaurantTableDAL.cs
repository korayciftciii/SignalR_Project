using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
  public  interface IRestaurantTableDAL : IGenericDAL<RestaurantTable>
    {
        public int GetTableCount();
        public int GetAvaliableTableCount();
        public int GetOccupiedTableCount();
        List<RestaurantTable> GetAvailableTables();
        List<RestaurantTable> GetOccupiedTables();
        void ToggleTableStatusToTrue(int tableId);
        void ToggleTableStatusToFalse(int tableId);
    }
}
