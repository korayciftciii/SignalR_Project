using Microsoft.EntityFrameworkCore;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Repositories;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.EntityFramework
{
    public class EFFoodDAL : GenericRepository<Food>, IFoodDAL
    {
        public EFFoodDAL(ApplicationContext context) : base(context)
        {
        }

        public List<Food> FoodGetWithCategory()
        {
            var context = new ApplicationContext();
            var values = context.Foods.Include(x => x.Category).ToList();
            return values;
        }
    }
}
