﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.DataTransferObjects.DiscountDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Discount";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7295/api/v1/Discount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View(new List<ResultDiscountDto>());
        }
        [HttpGet]
        public IActionResult DiscountAdd()
        {
            ViewData["Title"] = "Discount Add";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DiscountAdd(CreateDiscountDto discountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(discountDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7295/api/v1/Discount", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(discountDto);
        }
     
        public async Task<IActionResult> DiscountDelete(int discountId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7295/api/v1/Discount/{discountId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DiscountUpdate(int discountId)
        {
            ViewData["Title"] = "Discount Update";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7295/api/v1/Discount/{discountId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DiscountUpdate(UpdateDiscountDto discountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(discountDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7295/api/v1/Discount", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(discountDto);
        }
    }
}
