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
    public partial class ItemSaleByTender : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = Session["ItemSaleByTender_Model"] as QuanLyNhanSu.Web.Areas.ReportSales.Models.SaleReportModel;
            if (model != null)
            {
                var result = Session["ItemSaleByTenderData_Model"] as List<ItemSaleByTenderReport>;
                QuanLyNhanSu.Web.Reports.Devs.ItemSaleByTender teder = new Reports.Devs.ItemSaleByTender(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Item Sale By Tender Report");
                teder.DataSource = result;
                rpViewer.Report = teder;
                rpViewer.DataBind();
            }
            
        }
    }
}