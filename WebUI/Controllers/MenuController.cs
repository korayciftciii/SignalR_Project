using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.BasketDtos;
using WebUI.DataTransferObjects.FoodDtos;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int tableId)
        {
           
            ViewData["Title"] = "Menu";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/Food/FoodGetWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFoodWithCategoryDto>>(jsonData);
                ViewBag.TableId = tableId;
                return View(values);
            }
            return View(new List<ResultFoodWithCategoryDto>());
           
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int foodId,int tableId)
        {
         
            CreateBasketDto createBasket = new CreateBasketDto
            {
                FoodId = foodId,
                Count = 1,
                RestaurantTableId = tableId
                // Default count can be set to 1 or any other value as needed
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasket);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7295/api/v1/Basket", content);
            if (response.IsSuccessStatusCode)
            {
                var toggleResponse = await ToggleTableStatusToFalseAsync(tableId);
                if (toggleResponse)
                {
                return RedirectToAction("Index");
                }
                return RedirectToAction("Index","Tables");
            }
            return View();
        }

        private async Task<bool> ToggleTableStatusToFalseAsync(int tableId)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(""); // Boş body zorunlu
            var response = await client.PutAsync(
                $"https://localhost:7295/api/v1/RestaurantTable/ToggleTableStatusToFalse/{tableId}", content);

            return response.IsSuccessStatusCode;
        }

    }
}
