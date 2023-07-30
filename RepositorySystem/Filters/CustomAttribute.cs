using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RepositorySystemDotNetCore.Filters
{
    public class CustomAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var UserCookie = filterContext.HttpContext.Request.Cookies["UserId"];
            if (UserCookie == null)
            {
                var result = new RedirectResult("/Admin/Account/LoginView");
                filterContext.Result = result;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
