using Microsoft.AspNetCore.Mvc;
using MovieProject.Data.EntityframeworkCore.Context;
using System.Linq;

namespace MovieProject.Controllers.Api
{
    [ApiController] //API attiribute aracılığıyla normal Controller görevinden çıkarılarak WebService tabanlı Controller olarak kullanımı
    public class CommentController : ControllerBase
    {
        #region Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an.

        private DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        #endregion Veritabanı bağlantısını StartUp aracılığıyla singleton olarak SOLID prensipleri dahilinde alındığı an.

        #region Film detayı kısmında Api aracılığıyla "Yorumlar"ın gösterilmesini sağlayan Metod.

        [Route("api/movie-comments")]//Api Routing
        [HttpGet]
        public ObjectResult GetComments(int MovieID)
        {
            return Ok(_context.MovieComment.Where(x => x.MovieID == MovieID)
                                                                      .OrderByDescending(x => x.CreatedDate)
                                                                      .Select(x => new { Message = string.Format("{0} {1} ({2})", x.CreatedDate, x.CommentText, x.User.FullName) })
                                                                      .ToList());
        }

        #endregion Film detayı kısmında Api aracılığıyla "Yorumlar"ın gösterilmesini sağlayan Metod.
    }
}