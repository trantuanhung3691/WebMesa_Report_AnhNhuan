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
    public class ItemSaleByDesController : BaseControler
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
            model.Condition = Request["Condition"].ToString();
            if (model.SearchKey == null) model.SearchKey = "";
            var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getItemSaleByDesReport(model.StoriesID, model.FromDate, model.ToDate,model.SearchKey, model.Condition);
            Session["ItemSaleByDesData_Model"] = result;
            Session["ItemSaleByDes_Model"] = model;
            return View();
        }
    }
}