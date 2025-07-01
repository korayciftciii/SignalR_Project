using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
   public interface IDiscountService : IGenericService<Discount>
    {
        public int TGetDiscountCount();
        public int TGetActiveDiscountCount();
        public int TGetInActiveDiscountCount();
    }
}
