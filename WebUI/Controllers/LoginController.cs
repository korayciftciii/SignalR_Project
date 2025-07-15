using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.EntityLayer.Entities;
using WebUI.DataTransferObjects.IdentityDtos;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(loginDto);
            }
        }
    }
}
