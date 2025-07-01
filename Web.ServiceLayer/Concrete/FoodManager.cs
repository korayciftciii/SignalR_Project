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
  public  class FoodManager : IFoodService
    {
        private readonly IFoodDAL _foodDAL;

        public FoodManager(IFoodDAL foodDAL)
        {
            _foodDAL = foodDAL;
        }

        public void TDelete(Food entity)
        {
            _foodDAL.Delete(entity);
        }

        public List<Food> TFoodGetWithCategory()
        {
            var data = _foodDAL.FoodGetWithCategory();
            return data;
        }

        public List<Food> TGetAll()
        {
            var data = _foodDAL.GetAll();
      
            return data;
        }

        public Food TGetById(int id)
        {
           var datum=_foodDAL.GetById(id);
      
            return datum;
        }

        public void TInsert(Food entity)
        {
          _foodDAL.Insert(entity);
        }

        public void TUpdate(Food entity)
        {
            _foodDAL.Update(entity);
        }
    }
}
