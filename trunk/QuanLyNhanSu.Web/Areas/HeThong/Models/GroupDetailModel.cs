
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Areas.HeThong.Models
{
    public class GroupDetailModel
    {
       
        public int GroupID { get; set; }
        public List<QuanLyNhanSu.Web.Models.GroupFuctionDetail> ListFunction { get; set; }
    }
}