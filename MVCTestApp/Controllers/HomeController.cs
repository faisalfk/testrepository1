using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVCTestApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            // Load files from a static path
            //string xmlFile1 = ConfigurationManager.AppSettings["XMLFilesPath"].ToString() + "PricingCalculator.xml";
            //string xmlFile2 = ConfigurationManager.AppSettings["XMLFilesPath"].ToString() + string.Format("DealListReport_ReportType{0}.xml", 1);
            //XmlDocument xdoc1 = new XmlDocument();
            //xdoc1.Load(xmlFile1);
            //xdoc1.Load(xmlFile2);

            #region  Load from relative parent directory

            string _appRoot = HttpContext.Server.MapPath("~");
            //DirectoryInfo _parent = Directory.GetParent(_appRoot);
            //string _parentPath = _parent.FullName;

            string[] _path = _appRoot.Split(new char[] { '\\' });
            int _count = 1;
            string _elm = _path[_path.Length - _count];
            while(_elm == "")
            {
                _count++;
                if (_count < _path.Length)
                { _elm = _path[_path.Length - _count]; }
            }

            string _folderPath = "";
            for (int i =0; i < (_path.Length - _count); i++)
            {
                _folderPath += _path[i] + "\\";
            }

            _folderPath += "grp_dr\\bin\\ReportXMLSetting";
            string xmlFile3 = (_folderPath.Trim().EndsWith("\\") ? _folderPath: _folderPath + "\\") + string.Format("DealListReport_ReportType{0}.xml", 1);
            XmlDocument xdoc2 = new XmlDocument();
            xdoc2.Load(xmlFile3);

            #endregion

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}