using Microsoft.AspNetCore.Mvc;
using MovieProject.Data.EntityframeworkCore.Models;
using System.Linq;

namespace MovieProject.Controllers
{
    public class BaseController : Controller
    {
        #region Kullanıcının aktif dili basecontroller'a gömülerek tüm Controller üzerinden çekilmektedir.

        public Language Language
        {
            get
            {
                return (Language)HttpContext.Items.FirstOrDefault(x => x.Key.ToString() == "Language").Value;
            }
        }

        #endregion Kullanıcının aktif dili basecontroller'a gömülerek tüm Controller üzerinden çekilmektedir.
    }
}