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
        [HttpGet("GetAvailableTables")]
        public IActionResult GetAvailableTables()
        {
            var availableTables = _restaurantTableService.TGetAvailableTables();
            if (availableTables == null || !availableTables.Any())
            {
                return NotFound("No available tables found.");
            }
            var result = _mapper.Map<List<ResultRestaurantTableDto>>(availableTables);
            return Ok(result);
        }
        [HttpGet("GetOccupiedTables")]
        public IActionResult GetOccupiedTables()
        {
            var occupiedTables = _restaurantTableService.TGetOccupiedTables();
            if (occupiedTables == null || !occupiedTables.Any())
            {
                return NotFound("No occupied tables found.");
            }
            var result = _mapper.Map<List<ResultRestaurantTableDto>>(occupiedTables);
            return Ok(result);
        }
        [HttpGet("GetTableCount")]
        public IActionResult GetTableCount()
        {
            var count = _restaurantTableService.GetTableCount();
            return Ok(new { Count = count });
        }
        [HttpGet("GetAvailableTableCount")]
        public IActionResult GetAvaliableTableCount()
        {
            var count = _restaurantTableService.GetAvaliableTableCount();
            return Ok(new { Count = count });
        }
        [HttpGet("GetOccupiedTableCount")]
        public IActionResult GetOccupiedTableCount()
        {
            var count = _restaurantTableService.GetOccupiedTableCount();
            return Ok(new { Count = count });
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
        [HttpDelete("{id}")]
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
