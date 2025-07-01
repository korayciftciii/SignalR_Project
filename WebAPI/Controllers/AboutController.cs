using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.AboutDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ActionAbout()
        {
            var result =_mapper.Map<List<ResultAboutDto>>(_aboutService.TGetAll());
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult AboutContentDelete(int id)
        {
            var about = _aboutService.TGetById(id);
            if (about == null)
            {
                return NotFound();
            }
            _aboutService.TDelete(about);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateAboutContent(UpdateAboutDto about)
        {
            if (about == null)
            {
                return BadRequest("Reservation data is null");
            }
            var existingAboutContent = _aboutService.TGetById(about.AboutId);
            if (existingAboutContent == null)
            {
                return NotFound();
            }
            var updatedEntity = _mapper.Map(about, existingAboutContent);
            _aboutService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
        [HttpPost]
        public IActionResult AboutContentAdd(CreateAboutDto about)
        {
            if (about == null)
            {
                return BadRequest("About  data is null");
            }
            var aboutEntity = _mapper.Map<About>(about);
            _aboutService.TInsert(aboutEntity);
            return CreatedAtAction(nameof(AboutGetById), new { id = aboutEntity.AboutId }, aboutEntity);
        }
        [HttpGet("{id}")]
        public IActionResult AboutGetById(int id)
        {
            var value = _aboutService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
    }
}
