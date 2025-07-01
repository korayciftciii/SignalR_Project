using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.FoodDTO
{
   public class GetFoodByIdDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool FoodStatus { get; set; }

        // İlişkili kategori bilgisi
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
