using Business.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthHelper _authHelper;

        public AuthController(AuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewBag.LoginResult = "";


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var isSuccess = await _authHelper.SecureSignInAsync(userName, password);

            if (isSuccess == true)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.LoginResult = "No user found. Check login details...";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var isSuccess = _authHelper.SecureSignOutAsync();

            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public async Task<IActionResult> Err()
        {
            var isSuccess = _authHelper.SecureSignOutAsync();

            return RedirectToAction("Login", "Auth");
        }
    }
}
