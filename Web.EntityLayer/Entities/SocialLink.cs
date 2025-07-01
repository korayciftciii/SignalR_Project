using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.EntityLayer.Entities
{
  public  class SocialLink
    {
        public int SocialLinkId { get; set; }
        public string PlatformName { get; set; } = null!; // Örn: Instagram, LinkedIn
        public string Url { get; set; } = null!;          // Örn: https://instagram.com/dukkan
        public string? IconClass { get; set; }
    }
}
