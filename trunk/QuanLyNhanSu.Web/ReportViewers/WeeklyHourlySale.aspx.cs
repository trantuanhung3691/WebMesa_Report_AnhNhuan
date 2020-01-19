using Microsoft.Reporting.WebForms;
using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyNhanSu.Web.ReportViewers
{
    public partial class WeeklyHourlySale : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            var model = Session["WeeklyHourlySale_Model"] as QuanLyNhanSu.Web.Areas.ReportSales.Models.SaleReportModel;
            if (model != null)
            {
                var result = Session["WeeklyHourlySaleData_Model"] as List<WeeklyHourlySaleReport>;
                QuanLyNhanSu.Web.Reports.Devs.WeelyHourlySale teder = new Reports.Devs.WeelyHourlySale(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Sales Weekly  Hourly Report",result);
                teder.DataSource = result;
                rpViewer.Report = teder;
                rpViewer.DataBind();
            }
            //if (!IsPostBack)
            //{
            //    var model = Session["WeeklyHourlySale_Model"] as QuanLyNhanSu.Web.Areas.ReportSales.Models.SaleReportModel;
            //    if (model != null)
            //    {
            //        var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getListWeeklyHourlySaleReport(model.StoriesID, model.FromDate, model.ToDate);
            //        var ds = new ReportDataSource("dsWeeklyHourlySale", result);
            //        rpViewer.LocalReport.DataSources.Clear();
            //        rpViewer.LocalReport.ReportPath = "Reports/WeeklyHourlySale.rdlc";
            //        var dsLogo = new ReportDataSource("dsImage", WebCommons.DisplayCommons.ListLogo(model.StoriesID));
            //        rpViewer.LocalReport.EnableExternalImages = true;
            //        rpViewer.LocalReport.DataSources.Add(dsLogo);
            //        rpViewer.LocalReport.DataSources.Add(ds);
            //        rpViewer.DataBind();
            //        var prCongTy = new[]
            //                           {
            //                       new ReportParameter("prTitle", String.Format("Sales Weekly  Hourly Report")),
            //                       new ReportParameter("prStore",WebCommons.DisplayCommons.StoreName(model.StoriesID)),
            //                       new ReportParameter("prFromDateToDate",String.Format(ReportText.FromDateToDate,model.FromDate.ToString(DateFormat.VN),model.ToDate.ToString(DateFormat.VN)))
            //                   };
            //        rpViewer.LocalReport.SetParameters(prCongTy);
            //        rpViewer.LocalReport.Refresh();
            //        upInfor.Update();
            //    }
            //}
        }
    }
}