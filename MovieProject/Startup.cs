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
            services.AddSingleton<TranslationTransformer>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie();

            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:Project"])
            .UseLazyLoadingProxies());

            services.AddControllersWithViews();
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

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDynamicControllerRoute<TranslationTransformer>("/{**culture}");
            });
        }
    }
    public class TranslationTransformer : DynamicRouteValueTransformer
    {
        private const string StartCulture = "/tr";
        private const string StartController = "Movie";
        private const string StartAction = "Index";
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            if (httpContext.Request.Path == "/")
            {
                httpContext.Response.Redirect(StartCulture);
            }

            values["controller"] = StartController;
            values["action"] = StartAction;

            return values;
        }
    }
}


