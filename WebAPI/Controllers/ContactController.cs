using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<CreateContactDto> _validator;
        public ContactController(IContactService contactService, IMapper mapper, IValidator<CreateContactDto> validator)
        {
            _contactService = contactService;
            _mapper = mapper;
            _validator = validator;
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
           var validationResult = _validator.Validate(contactDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var entity = _mapper.Map<Contact>(contactDto);
            _contactService.TInsert(entity);
            return CreatedAtAction(nameof(ContactGetById), new { id = entity.ContactId }, entity);
        }

        [HttpPut("ToggleContactStatusToTrue/{contactId}")]
        public IActionResult ToggleContactStatusToTrue(int contactId)
        {
            var contact = _contactService.TGetById(contactId);
            if (contact == null)
            {
                return NotFound();
            }
            _contactService.TToggleContactStatusToTrue(contactId);
            return Ok("Contact status toggled successfully.");
        }
    }
}
