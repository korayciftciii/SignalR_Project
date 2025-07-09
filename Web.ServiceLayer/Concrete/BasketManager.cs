using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.DataTransferObject.BasketDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace Web.ServiceLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDAL _basketDAL;

        public BasketManager(IBasketDAL basketDAL)
        {
            _basketDAL = basketDAL;
        }

        public void TDelete(Basket entity)
        {
           _basketDAL.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            var data=_basketDAL.GetAll();
            return data;
        }

        public List<ResultBasketDto> TGetBasketByTableId(int id)
        {
            var data=_basketDAL.GetBasketByTableId(id);
            return data;
        }

        public Basket TGetById(int id)
        {
            var data=_basketDAL.GetById(id);
            return data;
        }

        public void TInsert(Basket entity)
        {
            _basketDAL.Insert(entity);
        }

        public void TUpdate(Basket entity)
        {
            _basketDAL.Update(entity);
        }
    }
}
