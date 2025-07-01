using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
   public interface IFoodService : IGenericService<Food>
    {
        List<Food> TFoodGetWithCategory();
        public int TGetFoodCount();
        public int TGetActiveFoodCount();
        public int TGetInActiveFoodCount();
    }
}
