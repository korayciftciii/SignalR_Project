using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
   public interface IOrderService : IGenericService<Order>
    {
        public int TGetOrderCount();
        public int TGetActiveOrderCount();
        public int TGetInActiveOrderCount();
        public decimal TGetDailyIncome();
    }
}
