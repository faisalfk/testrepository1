using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

        [Required(ErrorMessage = "Required")]
        public int DownloadType { get; set; }

        public IEnumerable<SelectListItem> AllReportTypes
        {
            get
            {
                return this.ReportTypes;
            }
        }

        public IEnumerable<SelectListItem> CountriesList
        {
            get
            {
                List<string> CountryList = new List<string>();
                IList<SelectListItem> CountryList2 = new List<SelectListItem>();
                CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (CultureInfo CInfo in CInfoList)
                {
                    RegionInfo R = new RegionInfo(CInfo.LCID);
                    if (!(CountryList.Contains(R.EnglishName)))
                    {
                        CountryList.Add(R.EnglishName);
                    }
                }

                CountryList.Sort();

                foreach(string str in CountryList)
                {
                    CountryList2.Add(new SelectListItem() { Selected = false, Text = str, Value = str });
                }

                return CountryList2;
            }
        }

        //public IEnumerable<SelectListItem> CountriesList
        //{
        //    get
        //    {
        //        IList<SelectListItem> CountryList = new List<SelectListItem>();
        //        CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        //        foreach (CultureInfo CInfo in CInfoList)
        //        {
        //            RegionInfo R = new RegionInfo(CInfo.LCID);
        //            if (!CountryList.Contains(new SelectListItem() { Selected = false, Text = R.EnglishName, Value = R.Name }))
        //            {
        //                CountryList.Add(new SelectListItem() { Selected = false, Text = R.EnglishName, Value = R.Name });
        //            }
        //        }
        //        return CountryList;
        //    }
        //}

        #endregion

        public ReportModel()
        {

        }


    }
}