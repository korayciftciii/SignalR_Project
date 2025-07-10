using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
  public interface INotificationService : IGenericService<Notification>
    {
        public int TGetUnreadNotificationCount();
        public int GetNotificationCount();
        List<Notification> GetUnreadNotifications();

    }
}
