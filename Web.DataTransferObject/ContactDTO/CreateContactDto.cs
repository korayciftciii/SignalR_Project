using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.ContactDTO
{
   public class CreateContactDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime ContactDate { get; set; }=DateTime.Now;
        public bool IsRead { get; set; } = false;

    }
}
