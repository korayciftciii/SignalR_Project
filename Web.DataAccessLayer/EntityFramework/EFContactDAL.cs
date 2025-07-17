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
    public class EFContactDAL : GenericRepository<Contact>, IContactDAL
    {
        public EFContactDAL(ApplicationContext context) : base(context)
        {
        }

        public void ToggleContactStatusToTrue(int contactId)
        {
            using var context = new ApplicationContext();
            var notification = context.Contacts
                .FirstOrDefault(n => n.ContactId == contactId);
            notification.IsRead = true; 
            context.SaveChanges(); // değişikliği veritabanına kaydet
        }
    }
}
