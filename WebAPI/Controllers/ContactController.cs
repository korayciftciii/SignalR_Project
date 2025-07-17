using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.AboutDTO;
using Web.DataTransferObject.ContactDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ActionContact()
        {
            var result = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult ContactGetById(int id)
        {
            var value = _contactService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult ContactDelete(int id)
        {
            var contact = _contactService.TGetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            _contactService.TDelete(contact);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Contact data is null");
            }
            var existingData = _contactService.TGetById(contactDto.ContactId);
            if (existingData == null)
            {
                return NotFound();
            }
            var updatedEntity = _mapper.Map(contactDto, existingData);
            _contactService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
        [HttpPost]
        public IActionResult ContactAdd(CreateContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Contact  data is null");
            }
            var entity = _mapper.Map<Contact>(contactDto);
            _contactService.TInsert(entity);
            return CreatedAtAction(nameof(ContactGetById), new { id = entity.ContactId }, entity);
        }
     
    }
}
