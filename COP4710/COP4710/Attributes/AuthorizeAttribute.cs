using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using COP4710.Models;
using COP4710.Models.Enumerations;
using COP4710.DataAccess;

namespace COP4710.Attributes
{

    public class AuthorizationAttribute : AuthorizeAttribute
    {
        public AccountType UserRole { get; set; }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            UserModel user = (UserModel)httpContext.Session["CurrentUser"];

            if (user == null)
                return false;
            else
                if (UserRole != 0 && ((UserRole & user.AccountType) != UserRole))
                    return false;

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.HttpContext.Session.Clear();
                FormsAuthentication.SignOut();
                filterContext.Result = new RedirectResult("/error/accessdenied");
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new HttpStatusCodeResult(403);
            else
                filterContext.Result = new HttpUnauthorizedResult();
        }


    }
}

