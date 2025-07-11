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
    public class EFNotificationDAL : GenericRepository<Notification>, INotificationDAL
    {
        public EFNotificationDAL(ApplicationContext context) : base(context)
        {
        }

        public int GetNotificationCount()
        {
            using var context = new ApplicationContext();
            var notificationCount = context.Notifications
                .Count();
            return notificationCount;
        }

        public int GetUnreadNotificationCount()
        {
            using var context = new ApplicationContext();
            var unreadCount = context.Notifications
                .Count(n => !n.Status);
            return unreadCount;
        }

        public List<Notification> GetUnreadNotifications()
        {
            using var context = new ApplicationContext();
            var unreadNotifications = context.Notifications
                .Where(n => !n.Status)
                .ToList();
            return unreadNotifications;
        }

        public void ToggleNotificationStatus(int notificationId)
        {
            using var context = new ApplicationContext();
            var notification = context.Notifications
                .FirstOrDefault(n => n.NotificationId == notificationId);
                notification.Status = !notification.Status; // true ise false, false ise true yap
                context.SaveChanges(); // değişikliği veritabanına kaydet
            
        }
    }
}
