using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COP4710.Models;
using COP4710.Models.Enumerations;


namespace COP4710.Attributes
{

    public class AuthorizationAttribute : ActionFilterAttribute, IActionFilter
    {
        public AccountType UserRole { get; set; }

        void OnActionExecuting(ActionExecutedContext filterContext)
        {
            base.OnActionExecuting(filterContext);

        }
    }
}

