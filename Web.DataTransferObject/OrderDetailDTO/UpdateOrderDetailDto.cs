using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.OrderDetailDTO
{
public    class UpdateOrderDetailDto
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
