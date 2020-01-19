using Microsoft.Reporting.WebForms;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Web.Areas.Reports.Models;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyNhanSu.Web.ReportViewers
{
    public partial class Consolidation : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = Session["ConsolidationData_Model"] as ConsolidationReport;
            if (result != null)
            {
                var model = Session["Consolidation_Model"] as ItemReportModel;
               //var ds = new ReportDataSource("dsTender", result);
                QuanLyNhanSu.Web.Reports.Devs.Consolidation teder = new Reports.Devs.Consolidation(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Consolidation Report",result);
                ASPxDocumentViewer1.Report = teder;
                ASPxDocumentViewer1.DataBind();

            }
            //if (!IsPostBack)
            //{
            //    //var model = Session["Consolidation_Model"] as QuanLyNhanSu.Web.Areas.Reports.Models.ItemReportModel;
            //    //if (model != null)
            //    //{
            //    //    var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getListConsolidationReport(model.StoriesID, model.FromDate, model.ToDate);
            //    //    var ds = new ReportDataSource("dsConsolidationHeader", result.listHeader);
            //    //    var ds1 = new ReportDataSource("dsConsolidationSaleCode", result.listSaleCode);
            //    //    var ds2 = new ReportDataSource("dsConsolidationPayment", result.listPayment);
            //    //    var ds3 = new ReportDataSource("dsConsolidationDiscount", result.listDiscount);
            //    //    var ds4 = new ReportDataSource("dsConsolidationMenu", result.listMenu);
            //    //    var dsLogo = new ReportDataSource("dsImage", WebCommons.DisplayCommons.ListLogo(model.StoriesID));
            //    //    rpViewer.LocalReport.DataSources.Clear();
            //    //    rpViewer.LocalReport.EnableExternalImages = true;
            //    //    rpViewer.LocalReport.ReportPath = "Reports/Consolidation.rdlc";
            //    //    rpViewer.LocalReport.DataSources.Add(ds);
            //    //    rpViewer.LocalReport.DataSources.Add(ds1);
            //    //    rpViewer.LocalReport.DataSources.Add(ds2);
            //    //    rpViewer.LocalReport.DataSources.Add(ds3);
            //    //    rpViewer.LocalReport.DataSources.Add(ds4);
            //    //    rpViewer.LocalReport.DataSources.Add(dsLogo);
            //    //    rpViewer.DataBind();
            //    //    var prCongTy = new[]
            //    //                       {
            //    //                   new ReportParameter("prTitle", String.Format("Consolidation Report Of Store")),
            //    //                   new ReportParameter("prStore",WebCommons.DisplayCommons.StoreName(model.StoriesID)),
            //    //                   new ReportParameter("prFromDateToDate",String.Format(ReportText.FromDateToDate,model.FromDate.ToString(DateFormat.VN),model.ToDate.ToString(DateFormat.VN)))
            //    //               };
            //    //    rpViewer.LocalReport.SetParameters(prCongTy);
            //    //    rpViewer.LocalReport.Refresh();
            //    //    upInfor.Update();
            //    //}
            //}
        }
    }
}