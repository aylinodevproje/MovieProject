using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Data.EntityframeworkCore.Context;
using MovieProject.Data.EntityframeworkCore.Models;
using MovieProject.Helper.Authorize;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    [CustomAuthorizeAttiribute]//Admin yetkisi kontrolü eğer normal bir kullanıcısıyla anasayfaya geri gönderen Attiribute'dür.
    public class AdminController : Controller
    {
        #region Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an ve Content Path için WebHost'a ulaşmak

        private DataContext _context;
        private IWebHostEnvironment _env;

        public AdminController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #endregion Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an ve Content Path için WebHost'a ulaşmak

        #region Yönetim Paneli - Dashboard ekranı

        [Route("yonetim-paneli")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion Yönetim Paneli - Dashboard ekranı

        #region Yönetim Paneli - Kullanıcı CRUD işlemleri

        [Route("kullanicilar")]
        public IActionResult UserList()
        {
            return View(_context.User.OrderByDescending(x => x.ID).ToList());
        }

        [HttpGet]
        [Route("kullanici-ekle")]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [Route("kullanici-ekle")]
        public IActionResult CreateUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.User.Add(user);
                    int saved = _context.SaveChanges();
                    if (saved > 0)
                    {
                        return Redirect("/kullanicilar");
                    }

                    ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
                }
            }
            catch (Exception)
            {
            }
            return View(user);
        }

        [HttpGet]
        [Route("kullanici-guncelle")]
        public IActionResult UpdateUser(int Id)
        {
            return View(_context.User.Where(x => x.ID == Id).ToList().FirstOrDefault());
        }

        [HttpPost]
        [Route("kullanici-guncelle")]
        public IActionResult UpdateTranslate(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orginal = _context.User.Find(user.ID);
                    _context.Entry(orginal).CurrentValues.SetValues(user);
                    int saved = _context.SaveChanges();
                    if (saved > 0)
                    {
                        return Redirect("/kullanicilar");
                    }

                    ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
                }
            }
            catch (Exception)
            {
            }
            return View(user);
        }

        [Route("kullanici-sil")]
        public IActionResult DeleteUser(int Id)
        {
            var item = _context.User.Where(x => x.ID == Id).ToList().FirstOrDefault();
            if (item != null)
            {
                _context.User.Remove(item);
                _context.SaveChanges();
            }

            return Redirect("/kullanicilar");
        }

        #endregion Yönetim Paneli - Kullanıcı CRUD işlemleri

        #region Yönetim Paneli - Film türleri - CRUD işlemleri

        [Route("film-turleri")]
        public IActionResult MovieTypeList()
        {
            return View(_context.MovieType.OrderByDescending(x => x.ID).ToList());
        }

        [HttpGet]
        [Route("film-turleri-ekle")]
        public IActionResult CreateMovieType()
        {
            ViewData["Language"] = _context.Language.ToList();

            return View();
        }

        [HttpPost]
        [Route("film-turleri-ekle")]
        public IActionResult CreateMovieType(MovieType movieType)
        {
            ViewData["Language"] = _context.Language.ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    _context.MovieType.Add(movieType);
                    int saved = _context.SaveChanges();
                    if (saved > 0)
                    {
                        return Redirect("/film-turleri");
                    }

                    ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
                }
            }
            catch (Exception)
            {
            }
            return View(movieType);
        }

        [HttpGet]
        [Route("film-turleri-guncelle")]
        public IActionResult UpdateMovieType(int Id)
        {
            ViewData["Language"] = _context.Language.ToList();

            return View(_context.MovieType.Where(x => x.ID == Id).ToList().FirstOrDefault());
        }

        [HttpPost]
        [Route("film-turleri-guncelle")]
        public IActionResult UpdateMovieType(MovieType movieType)
        {
            ViewData["Language"] = _context.Language.ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var orginal = _context.MovieType.Find(movieType.ID);
                    _context.Entry(orginal).CurrentValues.SetValues(movieType);
                    int saved = _context.SaveChanges();
                    if (saved > 0)
                    {
                        return Redirect("/film-turleri");
                    }

                    ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
                }
            }
            catch (Exception)
            {
            }
            return View(movieType);
        }

        [Route("film-turleri-sil")]
        public IActionResult DeleteMovieType(int Id)
        {
            var item = _context.MovieType.Where(x => x.ID == Id).ToList().FirstOrDefault();
            if (item != null)
            {
                _context.MovieType.Remove(item);
                _context.SaveChanges();
            }

            return Redirect("/film-turleri");
        }

        #endregion Yönetim Paneli - Film türleri - CRUD işlemleri

        #region Yönetim Paneli - Film CRUD işlemleri

        [Route("filmler")]
        public IActionResult MovieList()
        {
            return View(_context.Movie.OrderByDescending(x => x.ID).ToList());
        }

        [HttpGet]
        [Route("film-ekle")]
        public IActionResult CreateMovie()
        {
            ViewData["MovieTypes"] = _context.MovieType.OrderBy(x => x.Name).ToList();

            return View();
        }

        [HttpPost]
        [Route("film-ekle")]
        public async Task<IActionResult> CreateMovie(Movie movie, IFormFile file)
        {
            ViewData["MovieTypes"] = _context.MovieType.OrderBy(x => x.Name).ToList();

            try
            {
                if (file == null)
                {
                    ModelState.AddModelError("", "Lütfen fotoğraf yükleyiniz!");

                    return View(movie);
                }

                var uploads = Path.Combine(_env.WebRootPath, "images");

                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                movie.Photo = "/images/" + file.FileName;

                _context.Movie.Add(movie);
                int saved = _context.SaveChanges();
                if (saved > 0)
                {
                    return Redirect("/filmler");
                }
            }
            catch (Exception)
            {
            }

            ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");

            return View(movie);
        }

        [HttpGet]
        [Route("film-guncelle")]
        public IActionResult UpdateMovie(int Id)
        {
            ViewData["MovieTypes"] = _context.MovieType.OrderBy(x => x.Name).ToList();

            return View(_context.Movie.Where(x => x.ID == Id).ToList().FirstOrDefault());
        }

        [HttpPost]
        [Route("film-guncelle")]
        public async Task<IActionResult> UpdateMovie(Movie movie, IFormFile file)
        {
            ViewData["MovieTypes"] = _context.MovieType.OrderBy(x => x.Name).ToList();

            try
            {
                if (file != null)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "images");

                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    movie.Photo = "/images/" + file.FileName;
                }

                var orginal = _context.Movie.Find(movie.ID);
                _context.Entry(orginal).CurrentValues.SetValues(movie);
                int saved = _context.SaveChanges();
                if (saved > 0)
                {
                    return Redirect("/filmler");
                }

                ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
            }
            catch (Exception)
            {
            }
            return View(movie);
        }

        [Route("film-sil")]
        public IActionResult DeleteMovie(int Id)
        {
            var item = _context.Movie.Where(x => x.ID == Id).ToList().FirstOrDefault();
            if (item != null)
            {
                _context.Movie.Remove(item);
                _context.SaveChanges();
            }

            return Redirect("/filmler");
        }

        #endregion Yönetim Paneli - Film CRUD işlemleri

        #region Yönetim Paneli - Yorum İşlemleri

        [Route("film-yorumlari")]
        public IActionResult MovieCommentList()
        {
            return View(_context.MovieComment.OrderByDescending(x => x.ID).ToList());
        }

        [Route("yorum-sil")]
        public IActionResult DeleteMovieComment(int Id)
        {
            var item = _context.MovieComment.Where(x => x.ID == Id).ToList().FirstOrDefault();
            if (item != null)
            {
                _context.MovieComment.Remove(item);
                _context.SaveChanges();
            }

            return Redirect("/film-yorumlari");
        }

        #endregion Yönetim Paneli - Yorum İşlemleri

        #region Yönetim Paneli - Translate Crud İşlemleri

        [Route("translate")]
        public IActionResult TranslateList()
        {
            return View(_context.Translate.OrderByDescending(x => x.ID).ThenBy(x => x.Key).ToList());
        }

        [HttpGet]
        [Route("translate-ekle")]
        public IActionResult CreateTranslate()
        {
            ViewData["Language"] = _context.Language.ToList();

            return View();
        }

        [HttpPost]
        [Route("translate-ekle")]
        public IActionResult CreateTranslate(Translate translate)
        {
            ViewData["Language"] = _context.Language.ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Translate.Add(translate);
                    int saved = _context.SaveChanges();
                    if (saved > 0)
                    {
                        return Redirect("/translate");
                    }

                    ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
                }
            }
            catch (Exception)
            {
            }
            return View(translate);
        }

        [HttpGet]
        [Route("translate-guncelle")]
        public IActionResult UpdateTranslate(int Id)
        {
            ViewData["Language"] = _context.Language.ToList();

            return View(_context.Translate.Where(x => x.ID == Id).ToList().FirstOrDefault());
        }

        [HttpPost]
        [Route("translate-guncelle")]
        public IActionResult UpdateTranslate(Translate translate)
        {
            ViewData["Language"] = _context.Language.ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var orginal = _context.Translate.Find(translate.ID);
                    _context.Entry(orginal).CurrentValues.SetValues(translate);
                    int saved = _context.SaveChanges();
                    if (saved > 0)
                    {
                        return Redirect("/translate");
                    }

                    ModelState.AddModelError("", "Lütfen alanları kontrol ederek tekrar deneyiniz!");
                }
            }
            catch (Exception)
            {
            }
            return View(translate);
        }

        [Route("translate-sil")]
        public IActionResult DeleteTranslate(int Id)
        {
            var item = _context.Translate.Where(x => x.ID == Id).ToList().FirstOrDefault();
            if (item != null)
            {
                _context.Translate.Remove(item);
                _context.SaveChanges();
            }

            return Redirect("/translate");
        }

        #endregion Yönetim Paneli - Translate Crud İşlemleri

        #region Google Uyumlu Url Yapısı için slug işlemleri

        [Route("slug")]
        public JsonResult GenerateSlug(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return Json(phrase);
            }
            string str = RemoveAccent(phrase).ToLower();
            // invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens

            return Json(str);
        }

        public string RemoveAccent(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        #endregion Google Uyumlu Url Yapısı için slug işlemleri
    }
}