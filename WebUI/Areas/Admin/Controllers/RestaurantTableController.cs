using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.RestaurantTableDto;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestaurantTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Tables";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/RestaurantTable");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRestaurantTableDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultRestaurantTableDto>());
        }
        [HttpGet]
        public IActionResult RestaurantTableAdd()
        {
            ViewData["Title"] = "Table Add";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RestaurantTableAdd(CreateRestaurantTableDto tableDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(tableDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7295/api/v1/RestaurantTable", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(tableDto);
        }
        public async Task<IActionResult> RestaurantTableDelete(int restaurantTableId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7295/api/v1/RestaurantTable/{restaurantTableId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RestaurantTableUpdate(int restaurantTableId)
        {
            ViewData["Title"] = "Table Update";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7295/api/v1/RestaurantTable/{restaurantTableId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRestaurantTableDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RestaurantTableUpdate(UpdateRestaurantTableDto tableDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(tableDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7295/api/v1/RestaurantTable", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(tableDto);
        }
    }
}
