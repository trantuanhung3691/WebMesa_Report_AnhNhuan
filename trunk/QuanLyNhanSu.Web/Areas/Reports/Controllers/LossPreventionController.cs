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
    public class LossPreventionController : Controller
    {
        // GET: Reports/LossPrevention
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.ItemReportModel model)
        {
            if (!ModelState.IsValid)
                return View();
            
            model.StoriesID = Request["StoriesID"].ToString();
            var result = new QuanLyNhanSu.Web.ServiceDao.ReportServiceDao().getListLossPrevention(model.StoriesID, model.FromDate, model.ToDate);
            
            Session["LossPrevention_Model"] = model;
            Session["LossPreventionData_Model"] = result;
            return View();
        }
    }
}