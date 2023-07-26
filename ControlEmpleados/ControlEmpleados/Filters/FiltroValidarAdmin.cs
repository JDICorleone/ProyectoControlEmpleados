namespace ControlEmpleados.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class FiltroValidarAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.HttpContext.Session.GetString("ADMIN") == null)
            {
                if (context.HttpContext.Session.GetString("CORREO") == null)
                {
                    context.Result = new RedirectToActionResult("Login", "Home", null);
                }
                context.Result = new RedirectToActionResult("Index", "Home", null);


            }

            base.OnActionExecuting(context);
        }
    }
}
