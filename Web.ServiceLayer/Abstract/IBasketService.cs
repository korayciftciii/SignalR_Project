using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.BasketDTO;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
   public interface IBasketService : IGenericService<Basket>
    {
        List<ResultBasketDto> TGetBasketByTableId(int id);
    }
}
