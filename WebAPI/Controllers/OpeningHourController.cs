using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.OpeningHourDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OpeningHourController : ControllerBase
    {
        private readonly IOpeningHourService _openingHourService;
        private readonly IMapper _mapper;
        public OpeningHourController(IMapper mapper, IOpeningHourService openingHourService)
        {
            _mapper = mapper;
            _openingHourService = openingHourService;
        }
        [HttpGet]
        public IActionResult OpeningHourList()
        {
            var values = _mapper.Map<List<ResultOpeningHourDto>>(_openingHourService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult OpeningHourGetById(int id)
        {
            var value = _openingHourService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult OpeningHourDelete(int id)
        {
            var openingHour = _openingHourService.TGetById(id);
            if (openingHour == null)
            {
                return NotFound();
            }
            _openingHourService.TDelete(openingHour);
            return NoContent();
        }
        [HttpPost]
        public IActionResult OpeningHourAdd(CreateOpeningHourDto createOpeningHourDto)
        {
            if (createOpeningHourDto == null)
            {
                return BadRequest("Opening hour data is null");
            }
            // Map CreateOpeningHourDto to OpeningHour entity
            var openingHourEntity = _mapper.Map<OpeningHour>(createOpeningHourDto);
            _openingHourService.TInsert(openingHourEntity);
            // Assuming OpeningHour entity has an Id property
            return CreatedAtAction(nameof(OpeningHourGetById), new { id = openingHourEntity.OpeningHourId }, openingHourEntity);
        }
        [HttpPut]
        public IActionResult OpeningHourUpdate(UpdateOpeningHourDto updateOpeningHourDto)
        {
            if (updateOpeningHourDto == null)
            {
                return BadRequest("Opening Hour data is null");
            }
            var existingData = _openingHourService.TGetById(updateOpeningHourDto.OpeningHourId);
            if (existingData == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateOpeningHourDto, existingData);
            _openingHourService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
    }
}
