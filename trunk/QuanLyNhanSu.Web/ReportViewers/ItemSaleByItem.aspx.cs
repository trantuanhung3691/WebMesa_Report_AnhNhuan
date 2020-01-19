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
    public partial class ItemSaleByItem : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = Session["ItemSaleByItem_Model"] as QuanLyNhanSu.Web.Areas.ReportSales.Models.SaleReportModel;
            if (model != null)
            {
                var result = Session["ItemSaleByItemData_Model"] as List<ItemSaleByItemReport>;
                QuanLyNhanSu.Web.Reports.Devs.ItemSaleByItem teder = new Reports.Devs.ItemSaleByItem(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Item Sale By Bill Report");
                teder.DataSource = result;
                rpViewer.Report = teder;
                rpViewer.DataBind();

            }
           
        }
    }
}