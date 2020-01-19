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
    public class TenderController : BaseControler
    {
        // GET: Reports/Tender
        [HttpGet]
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
            var result = new ServiceDao.ReportServiceDao().getListTenderReport(model.StoriesID, model.FromDate, model.ToDate);
            Session["Tender_Model"] = model;
            Session["TenderData_Model"] = result;
            return View();
        }
    }
}