using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.DiscountDTO;
using Web.DataTransferObject.SliderDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult SliderGetById(int id)
        {
            var value = _sliderService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult SliderDelete(int id)
        {
            var slider = _sliderService.TGetById(id);
            if (slider == null)
            {
                return NotFound();
            }
            _sliderService.TDelete(slider);
            return NoContent();
        }
        [HttpPost]
        public IActionResult SliderAdd(CreateSliderDto createSliderDto)
        {
            if (createSliderDto == null)
            {
                return BadRequest("Slider data is null");
            }
            // Map CreateSliderDto to Slider entity
            var sliderEntity = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TInsert(sliderEntity);
            // Assuming Slider entity has an Id property
            return CreatedAtAction(nameof(SliderGetById), new { id = sliderEntity.SliderId }, sliderEntity);
        }
        [HttpPut]
        public IActionResult SliderUpdate(UpdateSliderDto updateSliderDto)
        {
            if (updateSliderDto == null)
            {
                return BadRequest("Slider data is null");
            }
            var existingData = _sliderService.TGetById(updateSliderDto.SliderId);
            if (existingData == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateSliderDto, existingData);
            _sliderService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
    }
}