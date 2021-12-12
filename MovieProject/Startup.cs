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
            services.AddSingleton<TranslationTransformer>();//Routing için singleton dependecy injector.

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie();//Kullanýcý giriþi ve yönetici giriþi için authentication tanýmlanmasý ve cookie'ye default deðer ile kayýt edilmesidir.

            //appsettings.json üzerinden veritabaný çekilerek entityframework'e aktarýlýp Singleton olarak tanýmlanmasý.
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:Project"])
            .UseLazyLoadingProxies());//Tablolar arasýnda baðlantýnýn otomatik hale lazyloading yapýlmasýný saðlayan metod

            services.AddControllersWithViews();//Controller ve View ile çalýþýlacaðýnýn belirtilmesi için tanýmlanan metod.
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

            //Authorization yetkilendirme iþlemleri için aktif hale getirilen metod
            app.UseAuthorization();

            //Authentication iþlemleri için aktif hale getirilen metod
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                //Dinamik ve Friendy linklemek için kurulan routing
                endpoints.MapDynamicControllerRoute<TranslationTransformer>("/{**culture}");
            });
        }
    }

    //Routing ayarlarýnýn gerçekleþtirildiði ve  aktif dilin HttpContext ile taþýnabilir hale getirildiði sýnýftýr.
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