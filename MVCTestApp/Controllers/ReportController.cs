using Infragistics.Documents.Excel;
using MVCTestApp.Common;
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

            if (reportData.DownloadType == 1)
            {
                string documentFileNameRoot = string.Format("GRPReport.xlsx");

                this.Response.Clear();
                this.Response.AppendHeader("content-disposition", "attachment; filename=" + documentFileNameRoot);
                this.Response.ContentType = "application/octet-stream";

                Workbook wb = new Workbook(WorkbookFormat.Excel2007);
                Worksheet ws1 = wb.Worksheets.Add("Sheet1");
                Worksheet ws2 = wb.Worksheets.Add("Sheet2");

                ws1.Rows[0].SetCellValue(0, "No1");
                ws1.Rows[0].SetCellValue(1, "No2");
                ws1.Rows[0].SetCellValue(2, "No3");

                Random random = new Random();

                for (int i = 1; i <= 10; i++)
                {
                    ws1.Rows[i].SetCellValue(0, random.Next(1, 100));
                    ws1.Rows[i].SetCellValue(1, random.Next(1, 100));
                    ws1.Rows[i].SetCellValue(2, random.Next(1, 100));
                }

                ws2.Rows[0].SetCellValue(0, "Report Type");
                ws2.Rows[0].SetCellValue(1, reportData.ReportType);
                ws2.Rows[1].SetCellValue(0, "Country");
                ws2.Rows[1].SetCellValue(1, reportData.Country);
                ws2.Rows[2].SetCellValue(0, "Start Date");
                ws2.Rows[2].SetCellValue(1, reportData.StartDate);
                ws2.Rows[3].SetCellValue(0, "End Date");
                ws2.Rows[3].SetCellValue(1, reportData.EndDate);

                wb.Save(this.Response.OutputStream);
            }
            else if (reportData.DownloadType == 2)
            {
                // Create OPEN XML document
                OpenXML.CreateOpenXMLExcelSheet();
            }

            return View(reportData);
        }

    }

}