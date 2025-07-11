using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Repositories;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.EntityFramework
{
    public class EFRestaurantTableDAL : GenericRepository<RestaurantTable>, IRestaurantTableDAL
    {
        public EFRestaurantTableDAL(ApplicationContext context) : base(context)
        {
        }

        public List<RestaurantTable> GetAvailableTables()
        {
          var values = new List<RestaurantTable>();
            using var context = new ApplicationContext();
            values = context.RestaurantTables.Where(t => t.IsAvailable == true).ToList();
            return values;
        }

        public int GetAvaliableTableCount()
        {
            using var context=new ApplicationContext();
            return context.RestaurantTables.Count(t=> t.IsAvailable==true);
        }

        public int GetOccupiedTableCount()
        {
            using var context = new ApplicationContext();
            var count=context.RestaurantTables.Count(t => t.IsAvailable == false);
            return count;
        }

        public List<RestaurantTable> GetOccupiedTables()
        {
            var values = new List<RestaurantTable>();
            using var context = new ApplicationContext();
            values = context.RestaurantTables.Where(t => t.IsAvailable == false).ToList();
            return values;
        }

        public int GetTableCount()
        {
           using var context=new ApplicationContext();
            var count =context.RestaurantTables.Count();
            return count;
        }
    }
}
