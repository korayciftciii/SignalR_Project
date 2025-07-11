using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.NotificationDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult NotificationGetById(int id)
        {
            var value = _notificationService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        
        [HttpDelete("{id}")]
        public IActionResult NotificationDelete(int id)
        {
            var notification = _notificationService.TGetById(id);
            if (notification == null)
            {
                return NotFound();
            }
            _notificationService.TDelete(notification);
            return NoContent();
        }
        [HttpPost]
        public IActionResult NotificationlAdd(CreateNotificationDto createNotificationDto)
        {
            if (createNotificationDto == null)
            {
                return BadRequest("Notification data is null");
            }
            // Map CreateTestimonialDto to Testimonial entity
            var notificationEntity = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TInsert(notificationEntity);
            // Assuming Testimonial entity has an Id property
            return CreatedAtAction(nameof(NotificationGetById), new { id = notificationEntity.NotificationId }, notificationEntity);
        }
        [HttpPut]
        public IActionResult NotificationUpdate(UpdateNotificationDto updateNotificationDto)
        {
            if (updateNotificationDto == null)
            {
                return BadRequest("Notification data is null");
            }
            var existingData = _notificationService.TGetById(updateNotificationDto.NotificationId);
            if (existingData == null)
            {
                return NotFound();
            }
            // Map UpdateDiscountDto to existing Discount entity
            var updatedEntity = _mapper.Map(updateNotificationDto, existingData);
            _notificationService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
        [HttpGet("UnreadNotificationCount")]
        public IActionResult UnreadNotificationCount()
        {
            var count = _notificationService.TGetUnreadNotificationCount();
            return Ok(new { Count = count });
        }
        [HttpGet("NotificationCount")]
        public IActionResult NotificationCount()
        {
            var count = _notificationService.GetNotificationCount();
            return Ok(new { Count = count });
        }
        [HttpGet("UnreadNotificationsList")]
        public IActionResult UnreadNotificationsList()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.GetUnreadNotifications());
            return Ok(values);
        }
        [HttpPut("ToggleNotificationStatus/{notificationId}")]
        public IActionResult ToggleNotificationStatus(int notificationId)
        {
            var notification = _notificationService.TGetById(notificationId);
            if (notification == null)
            {
                return NotFound();
            }
            _notificationService.ToggleNotificationStatus(notificationId);
            return Ok("Notification status toggled successfully.");
        }
    }
}
