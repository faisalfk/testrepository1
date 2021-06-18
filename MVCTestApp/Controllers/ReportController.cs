using MVCTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCTestApp.Controllers
{

    [Authorize(Roles = "Reports")]
    public class ReportController : Controller
    {
        
        [HttpGet]
        public ActionResult FetchReport()
        {
            ReportModel reportModel = new ReportModel();
            return View(reportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FetchReport(ReportModel reportData)
        {
            #region Reading data from form collection

            //ReportModel reportModel = new ReportModel();
            //reportModel.ReportType = reportData["ReportType"].ToString();
            //reportModel.Country = reportData["Country"].ToString();

            //DateTime outDate;
            //DateTime.TryParse(reportData["StartDate"], out outDate);
            //reportModel.StartDate = outDate;

            //DateTime.TryParse(reportData["EndDate"], out outDate);
            //reportModel.EndDate = outDate;

            #endregion


            return View(reportData);
        }

    }

}