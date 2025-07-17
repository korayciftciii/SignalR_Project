using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.ContactDTO
{
   public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime ContactDate { get; set; }
        public bool IsRead { get; set; }

    }
}
