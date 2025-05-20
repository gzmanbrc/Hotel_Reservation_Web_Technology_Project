using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelResProject.Controllers
{
    public class AccountController : Controller
    {
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
                // User login → Home/Index (rezervasyon sayfası)
                return RedirectToAction("Index", "Home");
            }
            // Hata mesajı gönder
            ViewBag.Error = "Kullanıcı adı, şifre veya rol yanlış!";
            return View();
        }

        // GET: /Account/Register (istersen bunu da ekleyebilirsin)
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            // Kullanıcıyı kaydetme işlemi
            using (var context = new DataAccessLayer.Data.ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DataAccessLayer.Data.ApplicationDbContext>()))
            {
                // Aynı kullanıcı adı var mı kontrol et
                var existingUser = context.Users.FirstOrDefault(u => u.Username == username);
                if (existingUser != null)
                {
                    ViewBag.Error = "Bu kullanıcı adı zaten mevcut!";
                    return View();
                }
                var user = new EntityLayer.Entities.User { Username = username, Password = password, Role = "user" };
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        // Çıkış (Logout)
        public ActionResult Logout()
        {
            // Oturumu temizle (örnek)
            //Session.Clear();
            return RedirectToAction("Login");
        }


    }
}

