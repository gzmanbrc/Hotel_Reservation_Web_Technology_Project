using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DataAccessLayer.Data;
using EntityLayer.Entities;

namespace HotelResProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(string username, string password, string role)
        {
            // Basit kontrol örneği
            if (role == "admin" && username == "admin" && password == "1234")
            {
                // Admin login → RoomType/Index
                return RedirectToAction("Index", "RoomType");
            }
            else if (role == "user" && username == "user" && password == "1234")
            {
                // Get user from database
                var user = _context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    // Store user ID in session
                    HttpContext.Session.SetInt32("UserId", user.Id);
                }

                // User login → Reservation/Index (rezervasyon sayfası)
                return RedirectToAction("Index", "Reservation");
            }
            // Hata mesajı gönder
            ViewBag.Error = "Kullanıcı adı, şifre veya rol yanlış!";
            return View();
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            // Kullanıcıyı kaydetme işlemi
            using (var context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>()))
            {
                // Aynı kullanıcı adı var mı kontrol et
                var existingUser = context.Users.FirstOrDefault(u => u.Username == username);
                if (existingUser != null)
                {
                    ViewBag.Error = "Bu kullanıcı adı zaten mevcut!";
                    return View();
                }
                var user = new User { Username = username, Password = password, Role = "user" };
                context.Users.Add(user);
                context.SaveChanges();

                // Store user ID in session
                HttpContext.Session.SetInt32("UserId", user.Id);
            }
            return RedirectToAction("Login");
        }

        // Çıkış (Logout)
        public ActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

