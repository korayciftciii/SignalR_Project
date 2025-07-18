using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.DataTransferObjects.BasketDtos;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int tableId)
        {
            ViewData["Title"] = "Basket";
            if (tableId <= 0)
            {
                return View(new List<ResultBasketDto>());
            }
            else {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://localhost:7295/api/v1/Basket/{tableId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                    ViewBag.TableId = tableId;
                    return View(values);
                }
                return View(new List<ResultBasketDto>());
            }
              
        }
        public async Task<IActionResult> BasketItemDelete(int basketId, int tableId)
        {
            var client = _httpClientFactory.CreateClient();

            // 1. Önce ürünü sil
            var response = await client.DeleteAsync($"https://localhost:7295/api/v1/Basket/{basketId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "An error occurred while deleting basket item.");
            }

            // 2. Ürün silindiyse, sepette başka ürün kaldı mı kontrol et
            var isBasketStillHasItems = await CheckBasketCountAsync(tableId);

            // 3. Eğer sepet boşsa, masa durumunu true (yani boş) yap
            if (!isBasketStillHasItems)
            {
                await ToggleTableStatusToTrueAsync(tableId);
            }

            return Ok(); // Başarılıysa her durumda OK döner
        }

        private async Task<bool> ToggleTableStatusToTrueAsync(int tableId)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(""); // Boş body zorunlu
            var response = await client.PutAsync(
                $"https://localhost:7295/api/v1/RestaurantTable/ToggleTableStatusToTrue/{tableId}", content);

            return response.IsSuccessStatusCode;
        }
        private async Task<bool> CheckBasketCountAsync(int tableId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7295/api/v1/Basket/{tableId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                // Deserialize işlemi (örnek olarak List kullandım, senin modele göre değişebilir)
                var basketItems = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);

                // Eğer liste varsa ve en az bir öğe varsa true döner
                return basketItems != null && basketItems.Count > 0;
            }

            return false;
        }

    }
}
