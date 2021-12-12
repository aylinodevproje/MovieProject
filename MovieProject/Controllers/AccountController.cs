using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Data.EntityframeworkCore.Context;
using MovieProject.Data.EntityframeworkCore.Models;
using MovieProject.Helper;
using MovieProject.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    public class AccountController : BaseController
    {
        #region Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an.

        private DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        #endregion Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an.

        #region Kullanıcının sisteme giriş yaptığı sayfa ve metodlar

        [Route("tr/giris-yap")]
        [Route("en/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("tr/giris-yap")]
        [Route("en/login")]
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

                if (user.IsAdmin)
                {
                    return RedirectToAction("Index", "Admin");
                }

                return Redirect("/" + Language.Culture);
            }

            ModelState.AddModelError("error", CultureHelper.GetValue("IsLoginError", HttpContext));

            return View();
        }

        #endregion Kullanıcının sisteme giriş yaptığı sayfa ve metodlar

        #region Kullanıcının üye olduğu sayfa ve metodlar

        [Route("tr/kayit-ol")]
        [Route("en/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("tr/kayit-ol")]
        [Route("en/register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var isUser = _context.User.Any(x => x.Email == model.UserName || x.UserName == model.UserName);//Kullanıcının daha önceden sisteme kayıt olup olmadığı durumu

            if (isUser)
            {
                ModelState.AddModelError("error", CultureHelper.GetValue("AnyUserError", HttpContext));
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
                    if (_context.SaveChanges() > 0)//Kullanıcı sistemde kayıtlı değilse sisteme kayıt anı.
                    {
                        return Redirect(CultureHelper.GetValue("LoginLink", HttpContext));
                    }
                }
                catch (System.Exception)
                {
                }

                ModelState.AddModelError("error", CultureHelper.GetValue("FormError", HttpContext));
            }
            return View();
        }

        #endregion Kullanıcının üye olduğu sayfa ve metodlar

        #region Kullanıcının sistemden çıkış yaptığı metod ve ilgili dile göre anasayfaya yönlendirilmesi

        [Route("tr/cikis-yap")]
        [Route("en/logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/" + Language.Culture);
        }

        #endregion Kullanıcının sistemden çıkış yaptığı metod ve ilgili dile göre anasayfaya yönlendirilmesi
    }
}