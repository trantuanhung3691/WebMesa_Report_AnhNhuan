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
    public class ItemSaleByItemController : BaseControler
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
            var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getItemSaleByItemReport(model.StoriesID, model.FromDate, model.ToDate);
            Session["ItemSaleByItem_Model"] = model;
            Session["ItemSaleByItemData_Model"] = result;
            return View();
        }
    }
}