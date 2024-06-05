using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
 

namespace TickUp.Models
{
    public class Autentificacao : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("user") == null)
            { 
                context.Result = new RedirectToActionResult("Login", "Usuario", null);
            }
        }
    }
}
