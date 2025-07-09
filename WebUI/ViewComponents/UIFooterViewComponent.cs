using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.FooterContentDtos;

namespace WebUI.ViewComponents
{
    public class UIFooterViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIFooterViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/FooterContent");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterContentDto>>(jsonData);

                var about = values.FirstOrDefault(); // ya da .SingleOrDefault() kullanabilirsin
                return View(about);
            }

            return View(new ResultFooterContentDto()); // boş bir nesne gönder, null riskine karşı
        }
    }
}
