using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.OrderDetailDTO;
using Web.DataTransferObject.OrderDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {

        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult OrderDetailList()
        {
            var values = _mapper.Map<List<ResultOrderDetailDto>>(_orderDetailService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult OrderDetailGetById(int id)
        {
            var value = _orderDetailService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpPost]
        public IActionResult OrderDetailAdd(CreateOrderDetailDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order Details data is null");
            }
            var entity = _mapper.Map<OrderDetail>(orderDto);
            _orderDetailService.TInsert(entity);
            return CreatedAtAction(nameof(OrderDetailGetById), new { id = entity.OrderDetailId }, orderDto);
        }
        [HttpPut]
        public IActionResult OrderDetailUpdate(UpdateOrderDetailDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order Details data is null");
            }
            var existingOrder = _orderDetailService.TGetById(orderDto.OrderDetailId);
            if (existingOrder == null)
            {
                return NotFound();
            }
            var updatedEntity = _mapper.Map(orderDto, existingOrder);
            _orderDetailService.TUpdate(updatedEntity);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult OrderDetailDelete(int id)
        {
            var order = _orderDetailService.TGetById(id);
            if (order == null)
            {
                return NotFound();
            }
            _orderDetailService.TDelete(order);
            return NoContent();
        }
    }
}
