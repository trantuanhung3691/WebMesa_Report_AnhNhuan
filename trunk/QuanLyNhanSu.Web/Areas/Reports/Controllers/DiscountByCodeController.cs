using QuanLyNhanSu.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.Areas.Reports.Controllers
{
    [AuthActionFilter]
    [Authorize]
    public class DiscountByCodeController : Controller
    {
        
        // GET: Reports/Consolidation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.ItemReportModel model)
        {
            if(!ModelState.IsValid)
                return View();
            model.StoriesID = Request["StoriesID"].ToString();
            var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getDiscountByCodeReport(model.StoriesID, model.FromDate, model.ToDate);
            Session["DiscountByCode_Model"] = model;
            Session["DiscountByCodeData_Model"] = result;
            return View();
        }
        
    }
}