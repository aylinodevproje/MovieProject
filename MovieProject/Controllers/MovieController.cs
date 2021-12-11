using Microsoft.AspNetCore.Mvc;
using MovieProject.Data.EntityframeworkCore.Context;
using System.Linq;

namespace Proje.Controllers
{
    public class MovieController : Controller
    {
        private DataContext _context;
        public MovieController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["MovieTypes"] = _context.MovieType
                .Where(x => x.Language.Culture == HttpContext.Request.Path.Value[1].ToString())
                .OrderBy(x => x.Name)
                .ToList();

            return View();
        }

        public IActionResult Detail()
        {
            ViewData["MovieTypes"] = _context.MovieType
                           .Where(x => x.Language.Culture == HttpContext.Request.Path.Value[1].ToString())
                           .OrderBy(x => x.Name)
                           .ToList();

            return View();
        }
    }
}
