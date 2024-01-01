using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPresentation.Controllers
{
    public class LoginController : Controller
    {
        // Kullanıcı giriş sayfası
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Kullanıcı girişi için POST işlemi
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "User", new { userId = user.Id });
                }
            }

            ViewBag.ErrorMessage = "Email veya şifre hatalı.";
            return View();
        }
    }
}
