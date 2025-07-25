﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
  public  interface IReservationService : IGenericService<Reservation>
    {
        public int TGetReservationCount();
        public int TGetActiveReservationCount();
        public int TGetInActiveReservationCount();
    }
}
