using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataTransferObject.BasketDTO;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
    public interface IBasketDAL : IGenericDAL<Basket>
    {
        List<ResultBasketDto> GetBasketByTableId(int id);
    }
}
