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
    public class EFCategoryDAL : GenericRepository<Category>, ICategoryDAL
    {
       
        public EFCategoryDAL(ApplicationContext context) : base(context)
        {
        }

        public int GetCategoryCount()
        {
           using var context= new ApplicationContext();
            return context.Categories.Count();
        }

        public int GetActiveCategoryCount()
        {
            using var context = new ApplicationContext();
            var count = context.Categories.Count(c => c.CategoryStatus == true);
            return count;
        }

        public int GetInactiveCategoryCount()
        {
           using var context=new ApplicationContext();
            var count = context.Categories.Count(c => c.CategoryStatus == false);
            return count;
        }
    }
}
