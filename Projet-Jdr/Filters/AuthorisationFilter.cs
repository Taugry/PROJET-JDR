using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Jdr.Filters
{
    public class AuthorisationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["Admin"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Login/Authorisation", false);
            }
        }
    }
}