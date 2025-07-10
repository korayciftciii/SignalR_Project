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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDAL _notificationDAL;

        public NotificationManager(INotificationDAL notificationDAL)
        {
            _notificationDAL = notificationDAL;
        }

        public int GetNotificationCount()
        {
            var count = _notificationDAL.GetNotificationCount();
            return count;
        }

        public List<Notification> GetUnreadNotifications()
        {
            var data = _notificationDAL.GetUnreadNotifications();
            return data;
        }

        public void TDelete(Notification entity)
        {
            _notificationDAL.Delete(entity);
        }

        public List<Notification> TGetAll()
        {
            var data = _notificationDAL.GetAll();
            return data;
        }

        public Notification TGetById(int id)
        {
            var datum = _notificationDAL.GetById(id);
            return datum;
        }

        public int TGetUnreadNotificationCount()
        {
           var count=_notificationDAL.GetUnreadNotificationCount();
            return count;
        }

        public void TInsert(Notification entity)
        {
            _notificationDAL.Insert(entity);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDAL.Update(entity);
        }
    }
}
