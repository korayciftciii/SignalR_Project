using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace Web.ServiceLayer.Concrete
{
    public class RestaurantTableManager : IRestaurantTableService
    {
        private readonly IRestaurantTableDAL _restaurantTableDAL;

        public RestaurantTableManager(IRestaurantTableDAL restaurantTableDAL)
        {
            _restaurantTableDAL = restaurantTableDAL;
        }

        public int GetAvaliableTableCount()
        {
            var count=_restaurantTableDAL.GetAvaliableTableCount();
            return count;
        }

        public int GetOccupiedTableCount()
        {
            var count = _restaurantTableDAL.GetOccupiedTableCount();
            return count;
        }

        public int GetTableCount()
        {
            var count=_restaurantTableDAL.GetTableCount();
            return count;
        }

        public void TDelete(RestaurantTable entity)
        {
           _restaurantTableDAL.Delete(entity);
        }

        public List<RestaurantTable> TGetAll()
        {
            var data = _restaurantTableDAL.GetAll();
            return data;
        }

        public List<RestaurantTable> TGetAvailableTables()
        {
            var values=_restaurantTableDAL.GetAvailableTables();
            return values;
        }

        public RestaurantTable TGetById(int id)
        {
            var item = _restaurantTableDAL.GetById(id);
            return item;
        }

        public List<RestaurantTable> TGetOccupiedTables()
        {
            var values = _restaurantTableDAL.GetOccupiedTables();
            return values;
        }

        public void TInsert(RestaurantTable entity)
        {
           _restaurantTableDAL.Insert(entity);
        }

        public void TToggleTableStatusToFalse(int tableId)
        {
            _restaurantTableDAL.ToggleTableStatusToFalse(tableId);
        }

        public void TToggleTableStatusToTrue(int tableId)
        {
            _restaurantTableDAL.ToggleTableStatusToTrue(tableId);
        }

        public void TUpdate(RestaurantTable entity)
        {
          _restaurantTableDAL.Update(entity);
        }
    }
}
