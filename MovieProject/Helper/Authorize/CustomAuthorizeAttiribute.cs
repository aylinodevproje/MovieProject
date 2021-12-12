using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace MovieProject.Helper.Authorize
{
    //Admin kontrolü yapan sınıftır.
    public class CustomAuthorizeAttiribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated && context.HttpContext.User.FindFirst(ClaimTypes.Role).Value == "Admin")
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new RedirectResult("/tr");
            }

            base.OnActionExecuting(context);
        }
    }
}