using DevExpress.XtraReports.UI;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json.Linq;
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
    public partial class Tender : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = Session["Tender_Model"] as ItemReportModel;
            if (model != null)
            {
                var result = Session["TenderData_Model"] as List<TenderReport>;
                var ds = new ReportDataSource("dsTender", result);
                QuanLyNhanSu.Web.Reports.Devs.Tender teder = new Reports.Devs.Tender(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Tender Report");
                teder.DataSource = result;
                ASPxDocumentViewer1.Report= teder;
                ASPxDocumentViewer1.DataBind();

            }
            #region Deletel
            //if (!IsPostBack)
            //{
            //    //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "showWaiting();", true);
            //    ((ReportViewer)this.Master).ShowWaiting();
            //    var model = Session["Tender_Model"] as ItemReportModel;
            //    if (model != null)
            //    {
            //       var result= Session["TenderData_Model"] as List<TenderReport>;
            //        //var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getListTenderReport(model.StoriesID, model.FromDate, model.ToDate);
            //        var ds = new ReportDataSource("dsTender", result);
            //        QuanLyNhanSu.Web.Reports.Devs.Tender teder = new Reports.Devs.Tender();
            //        teder.DataSource = result;

            //        ASPxDocumentViewer1.Report = teder;
            //        ASPxDocumentViewer1.DataBind();

            //        //rpViewer.LocalReport.DataSources.Clear();
            //        //rpViewer.LocalReport.ReportPath = "Reports/Tender.rdlc";
            //        //var dsLogo = new ReportDataSource("dsImage", WebCommons.DisplayCommons.ListLogo(model.StoriesID));
            //        //rpViewer.LocalReport.EnableExternalImages = true;
            //        //rpViewer.LocalReport.DataSources.Add(dsLogo);
            //        //rpViewer.LocalReport.DataSources.Add(ds);
            //        //rpViewer.DataBind();
            //        //var prCongTy = new[]
            //        //                   {
            //        //               new ReportParameter("prTitle", String.Format("Tender Transaction Report Of Store {0}", model.StoriesID)),
            //        //               new ReportParameter("prFromDateToDate",String.Format(ReportText.FromDateToDate,model.FromDate.ToString(DateFormat.VN),model.ToDate.ToString(DateFormat.VN)))
            //        //           };
            //        //rpViewer.LocalReport.SetParameters(prCongTy);
            //        //rpViewer.LocalReport.Refresh();
            //        //upInfor.Update();

            //    }
            //    ((ReportViewer)this.Master).CloseWaiting();
            //    //ScriptManager.RegisterStartupScript((this.Master).Page, (this.Master).GetType(), "script", "closeWaiting();", true);
            //}
            #endregion
        }
    }
}