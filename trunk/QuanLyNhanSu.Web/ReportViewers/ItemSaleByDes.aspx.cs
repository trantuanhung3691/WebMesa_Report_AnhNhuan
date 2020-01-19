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
    public partial class ItemSaleByDes : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = Session["ItemSaleByDes_Model"] as QuanLyNhanSu.Web.Areas.ReportSales.Models.SaleReportModel;
            if (model != null)
            {
                var result = Session["ItemSaleByDesData_Model"] as List<ItemSaleByDesReport>;
                QuanLyNhanSu.Web.Reports.Devs.ItemSaleByDes teder = new Reports.Devs.ItemSaleByDes(model.StoriesID,
                    String.Format(ReportText.FromDateToDate, model.FromDate.ToString(DateFormat.VN), model.ToDate.ToString(DateFormat.VN)),
                    "Item Sale By Description Report",result);
                rpViewer.Report = teder;
                rpViewer.DataBind();

            }
        }
    }
}