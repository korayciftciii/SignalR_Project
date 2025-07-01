using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
   public interface ICategoryService : IGenericService<Category>
    {
        public int TGetCategoryCount();
        public int TGetActiveCategoryCount();
        public int TGetInActiveCategoryCount();
    }
}
