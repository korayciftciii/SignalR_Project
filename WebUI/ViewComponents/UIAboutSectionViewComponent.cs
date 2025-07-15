using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.AboutDtos;


namespace WebUI.ViewComponents
{
    public class UIAboutSectionViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIAboutSectionViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/About");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

                var about = values.FirstOrDefault(); // ya da .SingleOrDefault() kullanabilirsin
                return View(about);
            }

            return View(new ResultAboutDto()); // boş bir nesne gönder, null riskine karşı
        }
    }
}
