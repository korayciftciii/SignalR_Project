using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.DataTransferObjects.ReservationDtos;
using WebUI.Models;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateReservationDto createReservation)
    {
        if (!ModelState.IsValid)
        {
            return View(createReservation);
        }
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createReservation);
        var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7295/api/v1/Reservation", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
