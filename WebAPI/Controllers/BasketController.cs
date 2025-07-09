using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Migrations;
using Web.DataTransferObject.BasketDTO;
using Web.ServiceLayer.Abstract;
namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly IMapper _mapper;
    public BasketController(IBasketService basketService, IMapper mapper)
    {
        _basketService = basketService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetBasketByTableId(int id)
    {
        var result = _basketService.TGetBasketByTableId(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost]
    public IActionResult CreateBasket(CreateBasketDto createBasketDto)
    {
        using var context = new ApplicationContext();
        var foodPrice = context.Foods.Where(x => x.FoodId == createBasketDto.FoodId)
                .Select(x => x.Price)
                .FirstOrDefault();
        _basketService.TInsert(new Web.EntityLayer.Entities.Basket()
        {
            FoodId = createBasketDto.FoodId,
            RestaurantTableId = 1,
            Price = foodPrice,
            Count = createBasketDto.Count,
            TotalPrice = foodPrice * createBasketDto.Count
        });
        return Ok("Basket created successfully.");
    }
    [HttpDelete("{id}")]
    public IActionResult BasketDelete(int id)
    {
        var basket = _basketService.TGetById(id);
        if (basket == null)
        {
            return NotFound();
        }
        _basketService.TDelete(basket);
        return NoContent();
    }
}
