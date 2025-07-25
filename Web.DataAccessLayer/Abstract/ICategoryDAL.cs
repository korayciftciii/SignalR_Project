﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
    public interface ICategoryDAL : IGenericDAL<Category>
    {
        public int GetCategoryCount();
        public int GetActiveCategoryCount();
        public int GetInactiveCategoryCount();
    }
}
