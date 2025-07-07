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

        public int GetTableCount()
        {
           using var context=new ApplicationContext();
            var count =context.RestaurantTables.Count();
            return count;
        }
    }
}
