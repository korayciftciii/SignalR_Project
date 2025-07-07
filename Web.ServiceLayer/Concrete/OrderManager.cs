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
   public class OrderManager : IOrderService
    {

        private readonly IOrderDAL _orderDAL;

        public OrderManager(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public void TDelete(Order entity)
        {
            _orderDAL.Delete(entity);
        }

        public int TGetActiveOrderCount()
        {
            return _orderDAL.GetActiveOrderCount();
        }

        public List<Order> TGetAll()
        {
            var data = _orderDAL.GetAll();

            return data;
        }

        public Order TGetById(int id)
        {
            var datum = _orderDAL.GetById(id);

            return datum;
        }

        public decimal TGetDailyIncome()
        {
            var dailyIncome = _orderDAL.GetDailyIncome();
            return dailyIncome;
        }

        public int TGetInActiveOrderCount()
        {
            return _orderDAL.GetInactiveOrderCount();
        }

        public int TGetOrderCount()
        {
            return _orderDAL.GetOrderCount();
        }

        public void TInsert(Order entity)
        {
            _orderDAL.Insert(entity);
        }

        public void TUpdate(Order entity)
        {
            _orderDAL.Update(entity);
        }
    }
}
