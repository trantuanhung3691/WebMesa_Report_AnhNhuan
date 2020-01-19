using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    public class DashboadModel
    {
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public int selectType { get; set; }
        public string BranchID { get; set; }
        public int chartType { get; set; }
    }
}