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
