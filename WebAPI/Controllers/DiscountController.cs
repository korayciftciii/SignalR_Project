using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.DiscountDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IMapper mapper, IDiscountService discountService)
        {
            _mapper = mapper;
            _discountService = discountService;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult DiscountGetById(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult DiscountDelete(int id)
        {
            var discount = _discountService.TGetById(id);
            if (discount == null)
            {
                return NotFound();
            }
            _discountService.TDelete(discount);
            return NoContent();
        }
        [HttpPost]
        public IActionResult DiscountAdd(CreateDiscountDto createDiscountDto)
        {
            if (createDiscountDto == null)
            {
                return BadRequest("Discount data is null");
            }
            // Map CreateDiscountDto to Discount entity
            var discountEntity = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TInsert(discountEntity);
            // Assuming Discount entity has an Id property
            return CreatedAtAction(nameof(DiscountGetById), new { id = discountEntity.DiscountId }, discountEntity);
        }
        [HttpPut]
        public IActionResult DiscountUpdate(UpdateDiscountDto updateDiscountDto)
        {
            if (updateDiscountDto == null)
            {
                return BadRequest("Discount data is null");
            }
            var existingDiscount = _discountService.TGetById(updateDiscountDto.DiscountId);
            if (existingDiscount == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateDiscountDto, existingDiscount);
            _discountService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
    }
}
