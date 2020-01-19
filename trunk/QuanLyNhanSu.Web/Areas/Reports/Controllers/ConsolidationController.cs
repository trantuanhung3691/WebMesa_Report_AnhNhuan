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
    public class ConsolidationController : Controller
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
            var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getListConsolidationReport(model.StoriesID, model.FromDate, model.ToDate);
            Session["ConsolidationData_Model"] = result;
            Session["Consolidation_Model"] = model;
            return View();
        }
        
    }
}