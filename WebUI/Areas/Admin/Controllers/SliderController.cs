using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.CategoryDtos;
using WebUI.DataTransferObjects.RestaurantTableDto;
using WebUI.DataTransferObjects.SliderDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Sliders";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/Slider");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultSliderDto>());
        }
        [HttpGet]
        public IActionResult SliderAdd()
        {
            ViewData["Title"] = "Slider Add";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderAdd(CreateSliderDto sliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(sliderDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7295/api/v1/Slider", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(sliderDto);
        }

        public async Task<IActionResult> SliderDelete(int sliderId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7295/api/v1/Slider/{sliderId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SliderUpdate(int sliderId)
        {
            ViewData["Title"] = "Slider Update";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7295/api/v1/Slider/{sliderId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderUpdate(UpdateSliderDto sliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(sliderDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7295/api/v1/Slider", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(sliderDto);
        }
    }
}
