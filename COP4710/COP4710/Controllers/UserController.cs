﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COP4710.Models;
using COP4710.Models.Enumerations;
using COP4710.DataAccess;
using COP4710.Attributes;

namespace COP4710.Controllers
{
    [Authorization(UserRole = AccountType.Administrator)]
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(UserDAO.ListUsers());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(string id)
        {
            return View(UserDAO.GetUserByUsername(id));
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                UserModel user = new UserModel();

                TryUpdateModel<UserModel>(user, collection.ToValueProvider());

                UserDAO.Insert(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(string id)
        {
            return View(UserDAO.GetUserByUsername(id));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                UserModel user = new UserModel();
                TryUpdateModel(user, collection.ToValueProvider());

                UserDAO.Update(user);

                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

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

        public List<SelectListItem> AjaxListUsersByName()
        {

            List<UserModel> users = UserDAO.ListUsers();
            List<SelectListItem> userItems = new List<SelectListItem>();

            users.ForEach(delegate(UserModel user)
            {
                userItems.Add(new SelectListItem() { Text = user.FirstName + " " + user.LastName, Value = user.UserName });
            });

            return userItems;
        }
    }
}
