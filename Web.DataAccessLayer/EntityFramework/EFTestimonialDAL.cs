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
    public class EFTestimonialDAL : GenericRepository<Testimonial>, ITestimonialDAL
    {
        public EFTestimonialDAL(ApplicationContext context) : base(context)
        {
        }

        public int GetActiveTestimonialCount()
        {
            var context=new ApplicationContext();
            return context.Testimonials.Count(x => x.CommentStatus);
        }

        public int GetInactiveTestimonialCount()
        {
            var context = new ApplicationContext();
            return context.Testimonials.Count(x => !x.CommentStatus);
        }

        public int GetTestimonialCount()
        {
            var context = new ApplicationContext();
            return context.Testimonials.Count();
        }
    }
}
