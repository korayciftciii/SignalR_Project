using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.DataTransferObjects.FooterContentDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterContentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterContentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/FooterContent");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UpdateFooterContentDto>>(jsonData);

                var about = values.FirstOrDefault(); // ya da .SingleOrDefault() kullanabilirsin
                return View(about);
            }

            return View(new UpdateFooterContentDto()); // boş bir nesne gönder, null riskine karşı
        }
        [HttpPost]
        public async Task<IActionResult> Index(UpdateFooterContentDto aboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(aboutDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7295/api/v1/FooterContent", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(aboutDto);
        }
    }
}
