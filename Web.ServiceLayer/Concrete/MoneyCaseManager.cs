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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDAL _moneyCaseDAL;

        public MoneyCaseManager(IMoneyCaseDAL moneyCaseDAL)
        {
            _moneyCaseDAL = moneyCaseDAL;
        }

        public void TDelete(MoneyCase entity)
        {
           _moneyCaseDAL.Delete(entity);
        }

        public List<MoneyCase> TGetAll()
        {
            var items=_moneyCaseDAL.GetAll();
            return items;
        }

        public MoneyCase TGetById(int id)
        {
            var item = _moneyCaseDAL.GetById(id);
            return item;
        }

        public decimal TGetTotalCaseAmount()
        {
            var totalAmount = _moneyCaseDAL.GetTotalCaseAmount();
            return totalAmount;
        }

        public void TInsert(MoneyCase entity)
        {
            _moneyCaseDAL.Insert(entity);
        }

        public void TUpdate(MoneyCase entity)
        {
            _moneyCaseDAL.Update(entity);
        }
    }
}
