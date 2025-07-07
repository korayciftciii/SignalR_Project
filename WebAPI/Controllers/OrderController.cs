using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.OrderDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _mapper.Map<List<ResultOrderDto>>(_orderService.TGetAll());
            return Ok(values);
        }
        [HttpGet("OrderCount")]
        public IActionResult OrderCount()
        {
            var count = _orderService.TGetOrderCount();
            return Ok(new { Count = count });
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var count = _orderService.TGetActiveOrderCount();
            return Ok(new { Count = count });
        }
        [HttpGet("InActiveOrderCount")]
        public IActionResult InActiveOrderCount()
        {
            var count = _orderService.TGetInActiveOrderCount();
            return Ok(new { Count = count });
        }
        [HttpGet("DailyIncome")]
        public IActionResult DailyIncome()
        {
            var income = _orderService.TGetDailyIncome();
            return Ok(new { Income = income });
        }
        [HttpGet("{id}")]
        public IActionResult OrderGetById(int id)
        {
            var value = _orderService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpPost]
        public IActionResult OrderAdd(CreateOrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is null");
            }
            var entity = _mapper.Map<Order>(orderDto);
            _orderService.TInsert(entity);
            return CreatedAtAction(nameof(OrderGetById), new { id = entity.OrderId }, orderDto);
        }
        [HttpPut]
        public IActionResult OrderUpdate(UpdateOrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is null");
            }
            var existingOrder = _orderService.TGetById(orderDto.OrderId);
            if (existingOrder == null)
            {
                return NotFound();
            }
            var updatedEntity = _mapper.Map(orderDto, existingOrder);
            _orderService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult OrderDelete(int id)
        {
            var order = _orderService.TGetById(id);
            if (order == null)
            {
                return NotFound();
            }
            _orderService.TDelete(order);
            return NoContent();
        }
    }
}
