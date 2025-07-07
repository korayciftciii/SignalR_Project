using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.RestaurantTableDto;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IRestaurantTableService _restaurantTableService;
        private readonly IMapper _mapper;
        public RestaurantTableController(IRestaurantTableService restaurantTableService, IMapper mapper)
        {
            _restaurantTableService = restaurantTableService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult RestaurantTableList()
        {
            var values = _mapper.Map<List<ResultRestaurantTableDto>>(_restaurantTableService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult RestaurantTableGetById(int id)
        {
            var value = _restaurantTableService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpPost]
        public IActionResult RestaurantTableAdd(CreateRestaurantTableDto createRestaurantTableDto)
        {
            if (createRestaurantTableDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var restaurantTable = _mapper.Map<RestaurantTable>(createRestaurantTableDto);
            _restaurantTableService.TInsert(restaurantTable);
            return CreatedAtAction(nameof(RestaurantTableGetById), new { id = restaurantTable.RestaurantTableId }, restaurantTable);
        }
        [HttpPut]
        public IActionResult RestaurantTableUpdate(UpdateRestaurantTableDto updateRestaurantTableDto)
        {
            if (updateRestaurantTableDto == null)
            {
                return BadRequest("Table data is null");
            }
            var existingData = _restaurantTableService.TGetById(updateRestaurantTableDto.RestaurantTableId);
            if (existingData == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateRestaurantTableDto, existingData);
            _restaurantTableService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult RestaurantTableDelete(int id)
        {
            var restaurantTable = _restaurantTableService.TGetById(id);
            if (restaurantTable == null)
            {
                return NotFound();
            }
            _restaurantTableService.TDelete(restaurantTable);
            return NoContent();
        }
    }
}
