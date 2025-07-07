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

        public void TDelete(RestaurantTable entity)
        {
           _restaurantTableDAL.Delete(entity);
        }

        public List<RestaurantTable> TGetAll()
        {
            var data = _restaurantTableDAL.GetAll();
            return data;
        }

        public RestaurantTable TGetById(int id)
        {
            var item = _restaurantTableDAL.GetById(id);
            return item;
        }

        public void TInsert(RestaurantTable entity)
        {
           _restaurantTableDAL.Insert(entity);
        }

        public void TUpdate(RestaurantTable entity)
        {
          _restaurantTableDAL.Update(entity);
        }
    }
}
