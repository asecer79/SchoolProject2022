using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

    }
}