using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataTransferObject.TestimonialDTO
{
  public  class GetTestimonialByIdDto
    {
        public int TestimonialId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl { get; set; }
        public bool CommentStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
