using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Repositories;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.EntityFramework
{
    public class EFReservationDAL : GenericRepository<Reservation>, IReservationDAL
    {
        public EFReservationDAL(ApplicationContext context) : base(context)
        {
        }

        public int GetActiveReservationCount()
        {
            var context=new ApplicationContext();
            return context.Reservations
                      .Count(r => r.ReservationDate > DateTime.Now);

        }

        public int GetInactiveReservationCount()
        {
            var context = new ApplicationContext();
            return context.Reservations
                     .Count(r => r.ReservationDate <= DateTime.Now);
        }

        public int GetReservationCount()
        {
           var context = new ApplicationContext();
            return context.Reservations.Count();
        }
    }
}
