using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.SliderDTO
{
 public   class UpdateSliderDto
    {
        public int SliderId { get; set; }
        public string SliderTitle { get; set; } = null!;
        public string? SliderDescription { get; set; }
        public string? ButtonLabel { get; set; }
        public bool FeatureStatus { get; set; }
    }
}
