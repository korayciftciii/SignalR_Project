﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
   public interface ITestimonialDAL :IGenericDAL<Testimonial>
    {
        public int GetTestimonialCount();
        public int GetActiveTestimonialCount();
        public int GetInactiveTestimonialCount();
    }
}
