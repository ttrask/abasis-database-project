using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COP4710.Models;
using COP4710.Models.Enumerations;
using COP4710.DataAccess;

namespace COP4710.Controllers
{
    public class DispatchController : Controller
    {
        //
        // GET: /Dispatch/

        public ActionResult Index()
        {
            return View(DispatchDAO.List());
        }

        //
        // GET: /Dispatch/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Dispatch/Create

        public ActionResult Create()
        {
            return View(new DispatchModel());
        } 

        //
        // POST: /Dispatch/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DispatchModel form = new DispatchModel();

                TryUpdateModel<DispatchModel>(form , collection.ToValueProvider());

                DispatchDAO.Insert(form);

                return RedirectToAction("Index");
        
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Dispatch/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Dispatch/Edit/5

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
        // GET: /Dispatch/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Dispatch/Delete/5

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

        public List<SelectListItem> ListETA()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            for (int i = 0; i <= 60; i++)
            {
                list.Add(new SelectListItem(){ Text=i.ToString(), Value=i.ToString()});
            }

            return list;
        }
    }
}
