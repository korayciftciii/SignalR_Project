using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.CategoryDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGetById(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CategoryAdd(CreateCategoryDto category)
        {
            if (category == null)
            {
                return BadRequest("Category data is null");
            }
            var entity = _mapper.Map<Category>(category);
            _categoryService.TInsert(entity);
            return CreatedAtAction(nameof(CategoryGetById), new { id = entity.CategoryId }, category);
        }
        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDto category)
        {
            if (category == null)
            {
                return BadRequest("Category data is null");
            }
            var existingCategory = _categoryService.TGetById(category.CategoryId);
            if (existingCategory == null)
            {
                return NotFound();
            }
            var updatedEntity = _mapper.Map(category, existingCategory);
            _categoryService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.TDelete(category);
            return NoContent();
        }
    }
}
