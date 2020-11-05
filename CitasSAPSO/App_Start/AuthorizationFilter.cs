using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasSAPSO.App_Start
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {  
                return;
            }

            if (HttpContext.Current.Session["Identification"] == null )
            {
                filterContext.Result = new RedirectResult("~/Appointment/Index");
            }else if(HttpContext.Current.Session["functionary"] == null)
            {
                filterContext.Result = new RedirectResult("~/Appointment/Index");
            }
        }
    }
}