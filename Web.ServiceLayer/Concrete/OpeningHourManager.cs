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
    public class OpeningHourManager : IOpeningHourService
    {
        private readonly IOpeningHourDAL _openingHourDAL;

        public OpeningHourManager(IOpeningHourDAL openingHourDAL)
        {
            _openingHourDAL = openingHourDAL;
        }

        public void TDelete(OpeningHour entity)
        {
          _openingHourDAL.Delete(entity);
        }

        public List<OpeningHour> TGetAll()
        {
           var data=_openingHourDAL.GetAll();
      
            return data;
        }

        public OpeningHour TGetById(int id)
        {
            var datum = _openingHourDAL.GetById(id);
         
            return datum;
        }

        public void TInsert(OpeningHour entity)
        {
           _openingHourDAL.Insert(entity);
        }

        public void TUpdate(OpeningHour entity)
        {
           _openingHourDAL.Update(entity);
        }
    }
}
