using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using COP4710.DataAccess;
using COP4710.Services;
using COP4710.Models;
using ExcelLibrary;

namespace COP4710.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return RedirectToAction("Import");
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);

                new ExcelService().ImportFromExcel(path, (UserModel)Session["CurrentUser"]);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Import()
        {
            return View();
        }

        public ActionResult Export()
        {
            return View(new ReportModel() { StartDate = DateTime.Today.AddYears(-1), EndAge = 200, StartAge = 0, EndDate = DateTime.Today });
        }

        [HttpPost]
        public ActionResult Export(FormCollection collection)
        {
            ReportModel model = new ReportModel();

            TryUpdateModel<ReportModel>(model, collection.ToValueProvider());



            string filename = Server.MapPath("~/app_data/Reports/Report_" + DateTime.Today.ToString("MMddyyyy") + ".xls");
            string contentType = "application/vnd.ms-excel";

            ExcelLibrary.DataSetHelper.CreateWorkbook(filename, ReportDAO.ExecuteReport(model));

            if (System.IO.File.Exists(filename))
            {
                return File(new FileStream(filename, FileMode.Open), contentType, filename);
            }

            return View(model);
        }

    }
}
