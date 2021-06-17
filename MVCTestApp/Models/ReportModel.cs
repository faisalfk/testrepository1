using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestApp.Models
{
    public class ReportModel
    {
        private readonly IEnumerable<SelectListItem> ReportTypes = new List<SelectListItem>
        {
            new SelectListItem() { Selected = true, Text = "Select Report Type", Value = string.Empty },
            new SelectListItem() { Selected = false, Text = "Detailed Report", Value = "DETAILED" },
            new SelectListItem() { Selected = false, Text = "Summary Report", Value = "SUMMARY" }
        };

        #region Properties

        [Required(ErrorMessage ="Required")]
        public string ReportType { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }


        public IEnumerable<SelectListItem> AllReportTypes
        {
            get
            {
                return this.ReportTypes;
            }
        }

        #endregion

        public ReportModel()
        {

        }


    }
}