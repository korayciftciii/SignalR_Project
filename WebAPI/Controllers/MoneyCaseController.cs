using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataTransferObject.MoneyCaseDTO;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoneyCaseController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        private readonly IMapper _mapper;
        public MoneyCaseController(IMoneyCaseService moneyCaseService, IMapper mapper)
        {
            _moneyCaseService = moneyCaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MoneyCaseList()
        {
            var values = _mapper.Map<List<ResultMoneyCaseDto>>(_moneyCaseService.TGetAll());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult MoneyCaseGetById(int id)
        {
            var value = _moneyCaseService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpPost]
        public IActionResult MoneyCaseAdd(CreateMoneyCaseDto moneyCase)
        {
            if (moneyCase == null)
            {
                return BadRequest("Invalid money case data.");
            }
            var entity = _mapper.Map<MoneyCase>(moneyCase);
            _moneyCaseService.TInsert(entity);
            return CreatedAtAction(nameof(MoneyCaseGetById), new { id = entity.MoneyCaseId }, entity);
        }
        [HttpPut]
        public IActionResult MoneyCaseUpdate(UpdateMoneyCaseDto moneyCase)
        {
            if (moneyCase == null)
            {
                return BadRequest("Invalid money case data.");
            }
            var existingCase = _moneyCaseService.TGetById(moneyCase.MoneyCaseId);
            if (existingCase == null)
            {
                return NotFound("Money case not found.");
            }
            var entity = _mapper.Map(moneyCase, existingCase);
            _moneyCaseService.TUpdate(entity);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult MoneyCaseDelete(int id)
        {
            var moneyCase = _moneyCaseService.TGetById(id);
            if (moneyCase == null)
            {
                return NotFound();
            }
            _moneyCaseService.TDelete(moneyCase);
            return NoContent();

        }
        [HttpGet("TotalAmountOfCase")]
        public IActionResult TotalAmountOfCase()
        {
            var totalAmount = _moneyCaseService.TGetTotalCaseAmount();
            return Ok(new { TotalAmount = totalAmount });
        }
    }
}

