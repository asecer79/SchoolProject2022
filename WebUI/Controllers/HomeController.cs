using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;


namespace WebUI.Controllers
{
    
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

    }
}