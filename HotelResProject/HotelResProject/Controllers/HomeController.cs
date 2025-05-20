using System.Diagnostics;
using HotelResProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelResProject.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(string email, string password, string role)
        {
            // Basit �rnek
            if (email == "admin@example.com" && password == "1234" && role == "admin")
            {
                return RedirectToAction("AdminDashboard"); // admin sayfas� varsa
            }
            else if (email == "user@example.com" && password == "1234")
            {
                return RedirectToAction("Index"); // kullan�c� anasayfas�
            }
            else
            {
                ViewBag.Error = "Hatal� giri� bilgileri.";
                return View();
            }
        }

    }
}
