﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.NotificationDTO
{
   public class CreateNotificationDto
    {
        public string NotificationType { get; set; }
        public string Description { get; set; }
        public DateTime NotificationDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;
    }
}
