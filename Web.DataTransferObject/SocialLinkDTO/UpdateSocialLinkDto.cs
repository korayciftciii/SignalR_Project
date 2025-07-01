using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.SocialLinkDTO
{
  public  class UpdateSocialLinkDto
    {
        public int SocialLinkId { get; set; }
        public string PlatformName { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? IconClass { get; set; }
    }
}
