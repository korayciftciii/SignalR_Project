using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

using Web.EntityLayer.Entities;
using WebUI.DataTransferObjects.ContactDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Contact";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/Contact");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultContactDto>());
        }
     

        public async Task<IActionResult> ContactDelete(int contactId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7295/api/v1/Contact/{contactId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> ChangeStatusToTrue(int contactId)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(""); // Boş body zorunlu
            var response = await client.PutAsync(
                $"https://localhost:7295/api/v1/Contact/ToggleContactStatusToTrue/{contactId}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
