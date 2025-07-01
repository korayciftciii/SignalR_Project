using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.DiscountDTO;
using Web.DataTransferObject.FooterContentDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FooterContentController : ControllerBase
    {
        private readonly IFooterContentService _footerContentService;
        private readonly IMapper _mapper;
        public FooterContentController(IFooterContentService footerContentService, IMapper mapper)
        {
            _footerContentService = footerContentService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ActionResult()
        {
            var values = _mapper.Map<List<ResultFooterContentDto>>(_footerContentService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult FooterContentGetById(int id)
        {
            var value = _footerContentService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult FooterContentDelete(int id)
        {
            var footerContent = _footerContentService.TGetById(id);
            if (footerContent == null)
            {
                return NotFound();
            }
            _footerContentService.TDelete(footerContent);
            return NoContent();
        }
        [HttpPost]
        public IActionResult FooterContentAdd(CreateFooterContentDto createFooterContentDto)
        {
            if (createFooterContentDto == null)
            {
                return BadRequest("Footer content data is null");
            }
            // Map CreateFooterContentDto to FooterContent entity
            var footerContentEntity = _mapper.Map<FooterContent>(createFooterContentDto);
            _footerContentService.TInsert(footerContentEntity);
            // Assuming FooterContent entity has an Id property
            return CreatedAtAction(nameof(FooterContentGetById), new { id = footerContentEntity.FooterContentId }, footerContentEntity);
        }
        [HttpPut]
        public IActionResult FooterContentUpdate(UpdateFooterContentDto updateFooterContentDto)
        {
            if (updateFooterContentDto == null)
            {
                return BadRequest("Footer Content data is null");
            }
            var existingContent = _footerContentService.TGetById(updateFooterContentDto.FooterContentId);
            if (existingContent == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateFooterContentDto, existingContent);
            _footerContentService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
    }
}
