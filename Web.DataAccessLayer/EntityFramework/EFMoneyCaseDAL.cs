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
    public class EFMoneyCaseDAL : GenericRepository<MoneyCase>, IMoneyCaseDAL
    {
        public EFMoneyCaseDAL(ApplicationContext context) : base(context)
        {
        }

        public decimal GetTotalCaseAmount()
        {
            using var context = new ApplicationContext();
            return context.MoneyCases.Select(mc => mc.TotalAmount).FirstOrDefault();
        }
    }
}
