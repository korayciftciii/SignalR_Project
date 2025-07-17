using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;
using WebUI.DataTransferObjects.IdentityDtos;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewData["Title"] =values.UserName+ "Profile";
            UserProfileDto userProfileDto = new UserProfileDto
            {
                Email = values.Email,
                Name = values.Name,
                Surname = values.Surname,
                UserName = values.UserName
            };
            return View(userProfileDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserProfileDto userDto)
        {
            if (userDto.Password == userDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userDto.Name;
                user.Surname = userDto.Surname;
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "An error occured try again.");
                    return View(userDto);
                }
            }
            else
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View(userDto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login", new { area = "" }); // Login sayfasına yönlendir
        }
    }
}
