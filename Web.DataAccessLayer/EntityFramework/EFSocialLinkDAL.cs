﻿using System;
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
    public class EFSocialLinkDAL : GenericRepository<SocialLink>, ISocialLinkDAL
    {
        public EFSocialLinkDAL(ApplicationContext context) : base(context)
        {
        }
    }
}
