using Microsoft.Reporting.WebForms;
using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Commons;
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
    public partial class ItemSale : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = Session["ItemSale_Model"] as QuanLyNhanSu.Web.Areas.ReportSales.Models.SaleReportModel;
            if (model != null)
            {
                var result = Session["ItemSaleData_Model"] as List<ItemSaleReport>;
                QuanLyNhanSu.Web.Reports.Devs.ItemSale teder = new Reports.Devs.ItemSale(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Item Sale Report",result);
                rpViewer.Report = teder;
                rpViewer.DataBind();

            }
            //if (!IsPostBack)
            //{
            //    var model = Session["ItemSale_Model"] as QuanLyNhanSu.Web.Areas.ReportSales.Models.SaleReportModel;
            //    if (model != null)
            //    {
            //        var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getItemSaleReport(model.StoriesID, model.FromDate, model.ToDate);
            //        var ds = new ReportDataSource("dsItemSale", result);
            //        rpViewer.LocalReport.DataSources.Clear();
            //        rpViewer.LocalReport.ReportPath = "Reports/ItemSale.rdlc";
            //        var dsLogo = new ReportDataSource("dsImage", WebCommons.DisplayCommons.ListLogo(model.StoriesID));
            //        rpViewer.LocalReport.EnableExternalImages = true;
            //        rpViewer.LocalReport.DataSources.Add(dsLogo);
            //        rpViewer.LocalReport.DataSources.Add(ds);
                    
            //        rpViewer.DataBind();
            //        var prCongTy = new[]
            //                           {
            //                       new ReportParameter("prTitle", String.Format("Item Sale Report")),
            //                       new ReportParameter("prStore",WebCommons.DisplayCommons.StoreName(model.StoriesID)),
            //                       new ReportParameter("prFromDateToDate",String.Format(ReportText.FromDateToDate,model.FromDate.ToString(DateFormat.VN),model.ToDate.ToString(DateFormat.VN)))
            //                   };
            //        rpViewer.LocalReport.SetParameters(prCongTy);
            //        rpViewer.LocalReport.Refresh();
            //        upInfor.Update();
                    
            //        //if (!request)
            //        //{
            //        //    var fileFile = string.Format("{0}{1}", "Test", DateTime.Now.ToString("yyyy_MM_dd_hh_ss"));
            //        //    string FileName = "FichePreinscription_" + fileFile + ".pdf";
            //        //    string extension;
            //        //    string encoding;
            //        //    string mimeType;
            //        //    string[] streams;
            //        //    Warning[] warnings;
            //        //    Byte[] mybytes = rpViewer.LocalReport.Render("PDF", null,
            //        //                  out extension, out encoding,
            //        //                  out mimeType, out streams, out warnings);
            //        //    using (FileStream fs = File.Create(Server.MapPath("~/Reports/RdlcTemps/" + FileName)))
            //        //    {
            //        //        fs.Write(mybytes, 0, mybytes.Length);
            //        //    }
            //        //    Response.ClearHeaders();
            //        //    Response.ClearContent();
            //        //    Response.Buffer = true;
            //        //    Response.Clear();
            //        //    Response.Charset = "";
            //        //    Response.ContentType = "application/pdf";
            //        //    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + FileName + "\"");
            //        //    Response.WriteFile(Server.MapPath("~/Reports/RdlcTemps/" + FileName));
            //        //    Response.Flush();
            //        //    File.Delete(Server.MapPath("~/Reports/RdlcTemps/" + FileName));
            //        //    Response.Close();
            //        //    Response.End();
            //        //}
            //        //else
            //        //{
            //        //    var master = ((this.Master) as ReportViewer);
            //        //    if (master != null)
            //        //    {
            //        //        master.CreatePDFFile(rpViewer, "Item Sale Report");
            //        //    }
            //        //}
                    
            //    }
            //}
        }
    }
}