using Microsoft.AspNetCore.Http;
using MovieProject.Data.EntityframeworkCore.Context;
using MovieProject.Data.EntityframeworkCore.Models;
using System.Linq;

namespace MovieProject.Helper
{
    public static class CultureHelper
    {
        public static Language ReverseLanguage(HttpContext context)//Aktif dilin tersini geri veriri.
        {
            var contextService = (DataContext)context.RequestServices.GetService(typeof(DataContext));

            var language = (Language)context.Items.FirstOrDefault(x => x.Key.ToString() == "Language").Value;

            var reverseLanguage = contextService.Language.Where(x => x.ID != language.ID).ToList().FirstOrDefault();

            return reverseLanguage;
        }

        public static string GetValue(string key, HttpContext context)//Gelen anahtara göre kullanıcıya metinsel translate kelime veya cümlesini verir.
        {
            var contextService = (DataContext)context.RequestServices.GetService(typeof(DataContext));

            var language = (Language)context.Items.FirstOrDefault(x => x.Key.ToString() == "Language").Value;

            var translate = contextService.Translate.Where(x => x.Key == key && x.LanguageID == language.ID).ToList().FirstOrDefault();

            if (translate != null)
            {
                return translate.Value;
            }

            return language.Culture + "_" + key;
        }
    }
}