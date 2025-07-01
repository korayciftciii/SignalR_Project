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
    public class EFSliderDAL : GenericRepository<Slider>, ISliderDAL
    {
        public EFSliderDAL(ApplicationContext context) : base(context)
        {
        }

        public int GetActiveSliderCount()
        {
            var context = new ApplicationContext();
            return context.Sliders.Count(s => s.FeatureStatus);
        }

        public int GetInactiveSliderCount()
        {
            var context = new ApplicationContext();
            return context.Sliders.Count(s => !s.FeatureStatus);
        }

        public int GetSliderCount()
        {
            var context = new ApplicationContext();
            return context.Sliders.Count();
        }
    }
}
