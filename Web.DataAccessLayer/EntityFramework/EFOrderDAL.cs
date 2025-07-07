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
    public class EFOrderDAL : GenericRepository<Order>, IOrderDAL
    {
        public EFOrderDAL(ApplicationContext context) : base(context)
        {
        }
        public int GetActiveOrderCount()
        {
          using  var context = new ApplicationContext();
            return context.Orders.Count(o => o.IsCompleted == false);
        }

        public decimal GetDailyIncome()
        {
            using var context = new ApplicationContext();

            var today = DateTime.Today;

            return context.Orders
                .Where(o => o.IsCompleted == true && o.OrderDate == today)
                .Sum(o => o.TotalPrice);
        }

        public int GetInactiveOrderCount()
        {
            using var context = new ApplicationContext();
            return context.Orders.Count(o => o.IsCompleted == true);
        }

        public int GetOrderCount()
        {
            using var context = new ApplicationContext();
            return context.Orders.Count();
        }
    }
}
