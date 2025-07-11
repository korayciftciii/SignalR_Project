using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.NotificationDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet("Admin/Notification/NotificationDetail/{notificationId}")]
        public async Task<IActionResult> NotificationDetail(int notificationId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7295/api/v1/Notification/{notificationId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultNotificationDto>(jsonData);
                if (!values.Status)
                {
                    await ToggleNotificationStatusAsync(notificationId);
                }
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public IActionResult NotificationAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NotificationAdd(CreateNotificationDto notificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(notificationDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7295/api/v1/Notification", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(notificationDto);
        }
        public async Task<IActionResult> NotificationDelete(int notificationId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7295/api/v1/Notification/{notificationId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> NotificationUpdate(int notificationId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7295/api/v1/Notification/{notificationId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NotificationUpdate(UpdateNotificationDto notificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(notificationDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7295/api/v1/Notification", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(notificationDto);
        }
        private async Task<bool> ToggleNotificationStatusAsync(int notificationId)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(""); // Boş body zorunlu
            var response = await client.PutAsync(
                $"https://localhost:7295/api/v1/Notification/ToggleNotificationStatus/{notificationId}", content);

            return response.IsSuccessStatusCode;
        }
        public async Task<IActionResult> NotificationToggleStatus(int notificationId)
        {
            var success = await ToggleNotificationStatusAsync(notificationId);

            if (success)
                return RedirectToAction("Index");

            return View("Error");
        }
    }
}
