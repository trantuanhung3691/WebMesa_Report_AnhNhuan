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
    public class ItemSaleByTenderController : BaseControler
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
            var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getItemSaleByTenderReport(model.StoriesID, model.FromDate, model.ToDate);
            Session["ItemSaleByTender_Model"] = model;
            Session["ItemSaleByTenderData_Model"] = result;
            return View(model);
        }
    }
}