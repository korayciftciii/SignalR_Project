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
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDAL _reservationDAL;

        public ReservationManager(IReservationDAL reservationDAL)
        {
            _reservationDAL = reservationDAL;
        }

        public void TDelete(Reservation entity)
        {
          _reservationDAL.Delete(entity);
        }

        public List<Reservation> TGetAll()
        {
           var data = _reservationDAL.GetAll();
        
            return data;
        }

        public Reservation TGetById(int id)
        {
          var datum = _reservationDAL.GetById(id);
          
            return datum;
        }

        public void TInsert(Reservation entity)
        {
           _reservationDAL.Insert(entity);
        }

        public void TUpdate(Reservation entity)
        {
           _reservationDAL.Update(entity);
        }
    }
}
