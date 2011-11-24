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

                int rowsAffected = DispatchDAO.Insert(form);

                return RedirectToAction("Index");
        
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }
        
        //
        // GET: /Dispatch/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (id > 0)
                return View(DispatchDAO.GetDispatchByID(id));
            else
                return RedirectToAction("Index");
        }

        //
        // POST: /Dispatch/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            DispatchModel form = new DispatchModel();

            try
            {
                
                TryUpdateModel<DispatchModel>(form, collection.ToValueProvider());

                int rowsAffected = DispatchDAO.UpdateForm(form);
            }
            catch
            {
                return View();
            }

            try
            {
                return RedirectToAction("Edit", new { id = form.FormID });
            }
            catch
            {
                return RedirectToAction("Index");
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
