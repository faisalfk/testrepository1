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
            return View();
        }

        [HttpPost]
        public ActionResult FetchReport(string reportType)
        {
            return View();
        }

    }

}