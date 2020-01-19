using Microsoft.Reporting.WebForms;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Web.Areas.Reports.Models;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyNhanSu.Web.ReportViewers
{
    public partial class DiscountByCode : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = Session["DiscountByCodeData_Model"] as DiscountByCodeReportModel;
            if (result != null)
            {
                var model = Session["DiscountByCode_Model"] as ItemReportModel;
                QuanLyNhanSu.Web.Reports.Devs.DiscountByCode teder = new Reports.Devs.DiscountByCode(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Discount By Code Report",result.totalList,result.detailList,result.detailListDetail);

                rpViewer.Report = teder;
                rpViewer.DataBind();

            }
            
        }
    }
}