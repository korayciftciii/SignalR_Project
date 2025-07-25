﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
  public  interface ISliderService : IGenericService<Slider>
    {
        public int TGetSliderCount();
        public int TGetActiveSliderCount();
        public int TGetInActiveSliderCount();
    }
}
