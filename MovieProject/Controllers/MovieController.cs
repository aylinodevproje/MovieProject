using Microsoft.AspNetCore.Mvc;
using MovieProject.Controllers;
using MovieProject.Data.EntityframeworkCore.Context;
using MovieProject.Data.EntityframeworkCore.Models;
using System;
using System.Linq;

namespace Proje.Controllers
{
    public class MovieController : BaseController
    {
        #region Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an.

        private DataContext _context;

        public MovieController(DataContext context)
        {
            _context = context;
        }

        #endregion Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an.

        #region Anasayfa görevi veya Film türlerine göre açılan sayfadır.

        public IActionResult Index()
        {
            var slugSplit = HttpContext.Request.Path.Value.Split("/").Where(x => !string.IsNullOrEmpty(x)).ToList();

            //Türlerin kullanıcı diline göre view tarafına ViewData ile gönderilmesi
            ViewData["MovieTypes"] = _context.MovieType.Where(x => x.Language.ID == Language.ID)
                                                                                        .OrderBy(x => x.Name)
                                                                                        .ToList();

            //Filmlerin kullanıcı diline göre view tarafına View metodu tarafından iletilmesi.
            if (slugSplit.Count > 1)
                return View(
                    _context.Movie.Where(x => x.MovieType.LanguageID == Language.ID && x.MovieType.Slug == slugSplit[1]).OrderByDescending(x => x.ID).ToList());
            else
                return View(
                    _context.Movie.Where(x => x.MovieType.LanguageID == Language.ID).OrderByDescending(x => x.ID).ToList());
        }

        #endregion Anasayfa görevi veya Film türlerine göre açılan sayfadır.

        #region Film detay sayfası ve metodu.

        [Route("{culture}/{catalog}/{slug}")]
        public IActionResult Detail(string slug)
        {
            ViewData["MovieTypes"] = _context.MovieType.Where(x => x.Language.ID == Language.ID)
                                                   .OrderBy(x => x.Name)
                                                   .ToList();

            return View(_context.Movie.Where(x => x.MovieType.LanguageID == Language.ID && x.Slug == slug).ToList().FirstOrDefault());
        }

        #endregion Film detay sayfası ve metodu.

        #region Filmin altına yapılan yorumu JSON ile kayıt altına alınması metodu.

        [HttpPost]
        [Route(nameof(_AddComment))]
        public IActionResult _AddComment(MovieComment movieComment)
        {
            bool created = false;
            try
            {
                if (!string.IsNullOrEmpty(movieComment.CommentText))
                {
                    movieComment.CreatedDate = DateTime.Now;

                    _context.MovieComment.Add(movieComment);
                    created = _context.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
            }

            return Ok(created);
        }

        #endregion Filmin altına yapılan yorumu JSON ile kayıt altına alınması metodu.
    }
}