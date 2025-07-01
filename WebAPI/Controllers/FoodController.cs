using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.DiscountDTO;
using Web.DataTransferObject.FoodDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IMapper _mapper;
        public FoodController(IFoodService foodService, IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FoodList()
        {
            var values = _mapper.Map<List<ResultFoodDto>>(_foodService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult FoodGetById(int id)
        {
            var values = _mapper.Map<ResultFoodDto>(_foodService.TGetById(id));
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult FoodDelete(int id)
        {
            var food = _foodService.TGetById(id);
            if (food == null)
            {
                return NotFound();
            }
            _foodService.TDelete(food);
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult FoodAdd(CreateFoodDto createFoodDto)
        {
            if (createFoodDto == null)
            {
                return BadRequest("Food data is null");
            }
            // Map CreateFoodDto to Food entity
            var foodEntity = _mapper.Map<Food>(createFoodDto);
            _foodService.TInsert(foodEntity);
            // Assuming Food entity has an Id property
            return CreatedAtAction(nameof(FoodGetById), new { id = foodEntity}, foodEntity);
        }
        [HttpPut]
        public IActionResult FoodUpdate(UpdateFoodDto updateFoodDto)
        {
            if (updateFoodDto == null)
            {
                return BadRequest("Food data is null");
            }
            var existingFood = _foodService.TGetById(updateFoodDto.FoodId);
            if (existingFood == null)
            {
                return NotFound();
            }
            var updatedEntity = _mapper.Map(updateFoodDto, existingFood);
            _foodService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
    }
}
