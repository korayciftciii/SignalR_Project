using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Abstract
{
   public interface INotificationDAL : IGenericDAL<Notification>
    {
        public int GetUnreadNotificationCount();
        public int GetNotificationCount();
        List<Notification> GetUnreadNotifications();
    }
}
