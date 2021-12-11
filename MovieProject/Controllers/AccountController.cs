using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Data.EntityframeworkCore.Context;
using MovieProject.Data.EntityframeworkCore.Models;
using MovieProject.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    public class AccountController : Controller
    {
        private DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _context.User.Where(x => (x.Email == model.UserName || x.UserName == model.UserName) && x.Password == model.Password).FirstOrDefault();

            if (user != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.FullName));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Movie");
            }

            ModelState.AddModelError("error", "Kullanıcı bilgileriniz doğru değil!");

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var isUser = _context.User.Any(x => x.Email == model.UserName || x.UserName == model.UserName);

            if (isUser)
            {
                ModelState.AddModelError("error", "Bu bilgilerle daha önceden üyelik oluşturulmuş!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.User.Add(new User()
                    {
                        Email = model.Email,
                        FullName = model.FullName,
                        UserName = model.UserName,
                        IsAdmin = false,
                        Password = model.Password
                    });
                    if (_context.SaveChanges()>0)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                catch (System.Exception)
                {
                }

                ModelState.AddModelError("error", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Movie");
        }
    }
}
