using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace Web.ServiceLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDAL _orderDetailDAL;

        public OrderDetailManager(IOrderDetailDAL orderDetailDAL)
        {
            _orderDetailDAL = orderDetailDAL;
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDetailDAL.Delete(entity);
        }

        public List<OrderDetail> TGetAll()
        {
            var data = _orderDetailDAL.GetAll();
            return data;
        }

        public OrderDetail TGetById(int id)
        {
            var datum = _orderDetailDAL.GetById(id);
            return datum;
        }

        public void TInsert(OrderDetail entity)
        {
          _orderDetailDAL.Insert(entity);
        }

        public void TUpdate(OrderDetail entity)
        {
            _orderDetailDAL.Update(entity);
        }
    }
}
