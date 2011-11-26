using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP4710.Controllers
{
    public class AdminMenuController : Controller
    {
        //
        // GET: /AdminMenu/

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Dispatches()
        {
            return View();
        }


        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }
    }
}
