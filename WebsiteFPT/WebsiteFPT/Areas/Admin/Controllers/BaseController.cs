using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebsiteFPT.Models;


namespace WebsiteFPT.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
       
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Session["idAdmin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { Controller = "Login", action = "Login", Areas = "Admin" }));
            }    
            base.OnActionExecuted(filterContext);
        }
    }
}