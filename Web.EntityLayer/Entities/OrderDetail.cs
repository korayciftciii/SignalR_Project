﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EntityLayer.Entities
{
  public  class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductID { get; set; }
        public Food Food { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }



    }
}
