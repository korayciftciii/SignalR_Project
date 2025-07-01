using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EntityLayer.Entities
{
    public class FooterContent
    {
        public int FooterContentId { get; set; }
        public string? LocationLabel { get; set; }
        public string? LocationUrl { get; set; }
        public string? StoreNumber { get; set; }
        public string? StoreMail { get; set; }
        public string? FooterTitle { get; set; }
        public string? FooterDescription { get; set; }

    }

}
