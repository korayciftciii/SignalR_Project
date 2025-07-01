using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.DiscountDTO;
using Web.DataTransferObject.TestimonialDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        private readonly IMapper _mapper;
        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult TestimonialGetById(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            _testimonialService.TDelete(testimonial);
            return NoContent();
        }
        [HttpPost]
        public IActionResult TestimonialAdd(CreateTestimonialDto createTestimonialDto)
        {
            if (createTestimonialDto == null)
            {
                return BadRequest("Testimonial data is null");
            }
            // Map CreateTestimonialDto to Testimonial entity
            var testimonialEntity = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TInsert(testimonialEntity);
            // Assuming Testimonial entity has an Id property
            return CreatedAtAction(nameof(TestimonialGetById), new { id = testimonialEntity.TestimonialId }, testimonialEntity);
        }
        [HttpPut]
        public IActionResult TestimonialtUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            if (updateTestimonialDto == null)
            {
                return BadRequest("Testimonial data is null");
            }
            var existingData = _testimonialService.TGetById(updateTestimonialDto.TestimonialId);
            if (existingData == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateTestimonialDto, existingData);
            _testimonialService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
    }
}
