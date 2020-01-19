using Microsoft.Reporting.WebForms;
using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyNhanSu.Web.ReportViewers
{
    public partial class LossPrevention : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //var model = Session["LossPrevention_Model"] as QuanLyNhanSu.Web.Areas.Reports.Models.ItemReportModel;
            //if (model != null)
            //{
            //    var result = Session["LossPreventionData_Model"] as List<Models.LossPrevention>;
            //    QuanLyNhanSu.Web.Reports.Devs.LossPrevention teder = new Reports.Devs.LossPrevention(model.StoriesID,
            //        String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
            //        "Loss Prevention Report",null);
            //    teder.DataSource = result;
            //    rpViewer.Report = teder;
            //    rpViewer.DataBind();

            //}

            var model = Session["LossPrevention_Model"] as QuanLyNhanSu.Web.Areas.Reports.Models.ItemReportModel;
            if (model != null)
            {
                var result = Session["LossPreventionData_Model"] as Models.LossPreventionReport;
                QuanLyNhanSu.Web.Reports.Devs.LossPrevention teder = new Reports.Devs.LossPrevention(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Loss Prevention Report", result);
            
                rpViewer.Report = teder;
                rpViewer.DataBind();

            }

            //if (!IsPostBack)
            //{
            //    var model = Session["LossPrevention_Model"] as QuanLyNhanSu.Web.Areas.Reports.Models.ItemReportModel;
            //    if (model != null)
            //    {
            //        var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getListLossPrevention(model.StoriesID, model.FromDate, model.ToDate);
            //        var ds = new ReportDataSource("dsLossPrevention", result);
            //        rpViewer.LocalReport.DataSources.Clear();
            //        rpViewer.LocalReport.ReportPath = "Reports/LossPrevention.rdlc";
            //        var dsLogo = new ReportDataSource("dsImage", WebCommons.DisplayCommons.ListLogo(model.StoriesID));
            //        rpViewer.LocalReport.EnableExternalImages = true;
            //        rpViewer.LocalReport.DataSources.Add(dsLogo);
            //        rpViewer.LocalReport.DataSources.Add(ds);
            //        rpViewer.DataBind();
            //        var prCongTy = new[]
            //                           {
            //                       new ReportParameter("prTitle", String.Format("Loss Prevention Report")),
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