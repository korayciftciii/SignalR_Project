using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.DiscountDTO;
using Web.DataTransferObject.SocialLinkDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SocialLinkController : ControllerBase
    {
        private readonly ISocialLinkService _socialLinkService;
        private readonly IMapper _mapper;
        public SocialLinkController(ISocialLinkService socialLinkService, IMapper mapper)
        {
            _socialLinkService = socialLinkService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialLinkList()
        {
            var values = _mapper.Map<List<ResultSocialLinkDto>>(_socialLinkService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult SocialLinkGetById(int id)
        {
            var value = _socialLinkService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult SocialLinkDelete(int id)
        {
            var socialLink = _socialLinkService.TGetById(id);
            if (socialLink == null)
            {
                return NotFound();
            }
            _socialLinkService.TDelete(socialLink);
            return NoContent();
        }
        [HttpPost]
        public IActionResult SocialLinkAdd(CreateSocialLinkDto createSocialLinkDto)
        {
            if (createSocialLinkDto == null)
            {
                return BadRequest("Social link data is null");
            }
            // Map CreateSocialLinkDto to SocialLink entity
            var socialLinkEntity = _mapper.Map<SocialLink>(createSocialLinkDto);
            _socialLinkService.TInsert(socialLinkEntity);
            // Assuming SocialLink entity has an Id property
            return CreatedAtAction(nameof(SocialLinkGetById), new { id = socialLinkEntity.SocialLinkId }, socialLinkEntity);
        }
        [HttpPut]
        public IActionResult SocialLinkUpdate(UpdateSocialLinkDto updateSocialLinkDto)
        {
            if (updateSocialLinkDto == null)
            {
                return BadRequest("Social Link data is null");
            }
            var existingData = _socialLinkService.TGetById(updateSocialLinkDto.SocialLinkId);
            if (existingData == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateSocialLinkDto, existingData);
            _socialLinkService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
    }
}
