using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace BookStore.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller: {1} action: {2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}
