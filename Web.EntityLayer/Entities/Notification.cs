using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EntityLayer.Entities
{
  public  class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string Description { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool Status { get; set; }
    }
}
