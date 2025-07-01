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
    public class EFDiscountDAL : GenericRepository<Discount>, IDiscountDAL
    {
        public EFDiscountDAL(ApplicationContext context) : base(context)
        {
        }

        public int GetActiveDiscountCount()
        {
            var context=new ApplicationContext();
            return context.Discounts.Count(d => d.DiscountStatus && d.StartDate <= DateTime.UtcNow && d.EndDate >= DateTime.UtcNow);
        }

        public int GetDiscountCount()
        {
            var context = new ApplicationContext();
            return context.Discounts.Count();
        }

        public int GetInactiveDiscountCount()
        {
            var context = new ApplicationContext();
            return context.Discounts.Count(d => !d.DiscountStatus || d.EndDate < DateTime.UtcNow);
        }
    }
}
