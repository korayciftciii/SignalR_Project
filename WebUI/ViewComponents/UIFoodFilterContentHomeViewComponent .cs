using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.FoodDtos;

namespace WebUI.ViewComponents
{
    public class UIFoodFilterContentHomeViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIFoodFilterContentHomeViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/Food/FoodGetWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFoodWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultFoodWithCategoryDto>());
        }
    }
}
