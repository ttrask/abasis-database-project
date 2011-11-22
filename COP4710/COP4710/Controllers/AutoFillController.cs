using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP4710.Controllers
{
    public class AutoFillController : Controller
    {
        //
        // GET: /AutoFill/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AutoFill/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AutoFill/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AutoFill/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /AutoFill/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AutoFill/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AutoFill/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AutoFill/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
