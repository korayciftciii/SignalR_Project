﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
   public interface IDiscountDAL :IGenericDAL<Discount>
    {
        public int GetDiscountCount();
        public int GetActiveDiscountCount();
        public int GetInactiveDiscountCount();
    }

}
