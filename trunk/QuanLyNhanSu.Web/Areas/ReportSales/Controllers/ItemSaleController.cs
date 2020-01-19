using QuanLyNhanSu.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.Areas.ReportSales.Controllers
{
    [AuthActionFilter]
    [Authorize]
    public class ItemSaleController : BaseControler
    {
        // GET: Reports/WeeklyHourly
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.SaleReportModel model)
        {
            //if (!ModelState.IsValid)
            //    return View();
            model.StoriesID = Request["StoriesID"].ToString();
            var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getItemSaleReport(model.StoriesID, model.FromDate, model.ToDate);
            Session["ItemSaleData_Model"] = result;
            Session["ItemSale_Model"] = model;
            return View();
        }
    }
}