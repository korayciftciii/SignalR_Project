using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.CategoryDTO
{
   public class CreateCategoryDto
    {
        public string CategoryName { get; set; } = null!;
        public bool CategoryStatus { get; set; } = true;
    }
}
