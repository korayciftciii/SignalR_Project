using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.SocialLinkDtos;

namespace WebUI.ViewComponents
{
    public class UIFooterSocialViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIFooterSocialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/SocialLink");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialLinkDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultSocialLinkDto>());
        }
    }
}
