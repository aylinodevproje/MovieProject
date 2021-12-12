using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieProject.Data.EntityframeworkCore.Context;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TranslationTransformer>();//Routing i�in singleton dependecy injector.

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie();//Kullan�c� giri�i ve y�netici giri�i i�in authentication tan�mlanmas� ve cookie'ye default de�er ile kay�t edilmesidir.

            //appsettings.json �zerinden veritaban� �ekilerek entityframework'e aktar�l�p Singleton olarak tan�mlanmas�.
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:Project"])
            .UseLazyLoadingProxies());//Tablolar aras�nda ba�lant�n�n otomatik hale lazyloading yap�lmas�n� sa�layan metod

            services.AddControllersWithViews();//Controller ve View ile �al���laca��n�n belirtilmesi i�in tan�mlanan metod.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            //Authorization yetkilendirme i�lemleri i�in aktif hale getirilen metod
            app.UseAuthorization();

            //Authentication i�lemleri i�in aktif hale getirilen metod
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                //Dinamik ve Friendy linklemek i�in kurulan routing
                endpoints.MapDynamicControllerRoute<TranslationTransformer>("/{**culture}");
            });
        }
    }

    //Routing ayarlar�n�n ger�ekle�tirildi�i ve  aktif dilin HttpContext ile ta��nabilir hale getirildi�i s�n�ft�r.
    public class TranslationTransformer : DynamicRouteValueTransformer
    {
        private const string StartCulture = "/tr";
        private const string StartController = "Movie";
        private const string StartAction = "Index";

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            var context = (DataContext)httpContext.RequestServices.GetService(typeof(DataContext));

            if (httpContext.Request.Path == "/")
            {
                httpContext.Response.Redirect(StartCulture);
                values["controller"] = StartController;
                values["action"] = StartAction;

                var language = context.Language.Where(x => x.Culture.ToLower() == "tr").ToList().FirstOrDefault();

                httpContext.Items.Add("Language", language);

                return values;
            }
            else
            {
                var culture = httpContext.Request.Path.Value.Split("/")[1];

                var language = context.Language.Where(x => x.Culture.ToLower() == culture.ToLower()).ToList().FirstOrDefault();

                if (language == null)
                {
                    values["controller"] = "Error";
                    values["action"] = "Index";
                    return values;
                }

                httpContext.Items.Add("Language", language);

                values["controller"] = StartController;
                values["action"] = StartAction;

                return values;
            }
        }
    }
}