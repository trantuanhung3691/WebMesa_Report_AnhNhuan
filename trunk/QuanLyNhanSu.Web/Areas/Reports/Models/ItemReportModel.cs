using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Areas.Reports.Models
{
    public class ItemReportModel
    {
        public String StoriesName { get; set; }
        [Required(ErrorMessage ="Please select store!")]
        public String StoriesID { get; set; }
        [Required(ErrorMessage = "End date not empty!")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage ="Start date not empty!")]
        public DateTime ToDate { get; set; }
    }
}