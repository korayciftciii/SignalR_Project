﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.AboutDTO
{
   public class UpdateAboutDto
    {
        public int AboutId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}
