using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
   public interface IOrderDAL :IGenericDAL<Order>
    {
        public int GetOrderCount();
        public int GetActiveOrderCount();
        public int GetInactiveOrderCount();
        public decimal GetDailyIncome();
    }
}
