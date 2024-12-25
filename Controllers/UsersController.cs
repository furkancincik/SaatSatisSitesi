using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SaatSatisSitesi.Models;

namespace SaatSatisSitesi.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tüm kullanıcıları listele
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // Yeni kullanıcı ekle
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Kullanıcıyı düzenle
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Kullanıcı sil
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Kullanıcı Giriş Yap
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name); // Kullanıcı oturumu
                HttpContext.Session.SetInt32("UserId", user.Id); // Kullanıcı ID'sini oturumda tut
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Girilen bilgiler hatalı. Lütfen tekrar deneyin.";
            return View();
        }

        // Kullanıcı Kayıt Ol
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser == null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }

                ViewBag.Error = "Bu email zaten kayıtlı.";
                return View(user);
            }
            return View(user);
        }

        // Kullanıcı Oturumunu Sonlandır
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Tüm session'ı temizle
            return RedirectToAction("Index", "Home");
        }
    }
}
