using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Areas.ReportSales.Models
{
    public class SaleReportModel
    {
        public String StoriesName { get; set; }
        [Required(ErrorMessage = "Please select store!")]
        public String StoriesID { get; set; }
        [Required(ErrorMessage = "Datetime not empty!")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage ="Datetime not empty!")]
        public DateTime ToDate { get; set; }
        public string SearchKey { get; set; }
        [Required(ErrorMessage = "Please select condition!")]
        public string Condition { get; set; }
    }
}