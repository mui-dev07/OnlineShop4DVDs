using Microsoft.AspNetCore.Mvc;
using onlineShop4DVDs.Models;
using System.Diagnostics;

namespace onlineShop4DVDs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult albumStore()
        {
            return View();
        }

        public IActionResult events()
        {
            return View();
        }

        public IActionResult news()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult elements()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
