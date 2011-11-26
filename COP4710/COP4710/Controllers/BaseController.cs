using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using COP4710.Models;
using COP4710.Models.Enumerations;

namespace COP4710.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (User == null || (User != null && !User.Identity.IsAuthenticated))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                // Call the base
                base.OnAuthorization(filterContext);
            }

        }
    }
}