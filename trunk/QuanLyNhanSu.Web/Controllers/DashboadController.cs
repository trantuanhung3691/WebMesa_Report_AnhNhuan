

using QuanLyNhanSu.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuanLyNhanSu.Web.Controllers
{
    [AuthActionFilter]
    [Authorize]
    public class DashboadController : Controller
    {
        
        public ActionResult Index()
        {
            var now = DateTime.Now.AddDays(-1);
            var dashboard = new Models.DashboadModel();
            dashboard.FromDate = now.AddDays(-7);
            dashboard.ToDate = now;
            return View(dashboard);
        }
        [HttpPost]
        public ActionResult Index(string CongvanKeyWord = "")
        {
            
            return View();
        }
        public ActionResult Denie()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetCharts(string fromdate,string todate,string type)
        {
            DateTime? Frdate = null;
            DateTime? Todate = null;
            int Type = 1;
            try
            {
                Frdate = DateTime.Parse(fromdate);
                Todate = DateTime.Parse(todate);
            }
            catch(Exception ex)
            {
                if (Frdate == null)
                    Frdate = DateTime.Now.AddDays(-7);
                if (Todate == null)
                    Todate = Frdate;
            }
            if (string.IsNullOrEmpty(type))
                Type = 1;
            else
                Type = int.Parse(type);
            var listBranchs = Session[Commons.SessionKeys.BranchList] as List<QuanLyNhanSu.Web.Models.BranchUserModel>;
            var branchs = "";
            foreach(var item in listBranchs)
            {
                
                branchs += (string.IsNullOrEmpty(branchs)?item.BRANCHCODE:(","+item.BRANCHCODE));
            }
            var chartDao = new ServiceDao.ChartDao();
            var data = chartDao.getBranchChartJs(Frdate.Value, Todate.Value, branchs,Type);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetChartByBranch()
        {
            var fromdate = this.HttpContext.Request["fromDate"];
            var branchID = this.HttpContext.Request["branchID"];
            var type = this.HttpContext.Request["selectType"];
            var dashboard = new Models.DashboadModel();
            dashboard.FromDate = DateTime.Parse(fromdate);
            dashboard.ToDate = dashboard.FromDate;
            dashboard.BranchID = branchID;
            dashboard.chartType = 2;
            dashboard.selectType = int.Parse(type);
            return View(dashboard);
        }
        [HttpPost]
        public ActionResult GetChartByBranch(string fromdate,string toDate,string branchID,int selectType)
        {
            DateTime? Todate = null;
            DateTime? Fromdate = null;
            int Type = selectType;
            try
            {
                switch (selectType)
                {
                    case 1:
                    case 4:
                        Fromdate = DateTime.Parse(fromdate.Replace("/","-"));
                        Todate = DateTime.Parse(toDate.Replace("/", "-"));
                        break;
                    case 2:
                        Fromdate = DateTime.Parse(fromdate);
                        Todate = DateTime.Parse(toDate);
                        break;
                    case 3:
                        Fromdate = DateTime.Parse(fromdate);
                        Todate = DateTime.Parse(toDate);
                        break;
                }
                
            }
            catch (Exception ex)
            {
                if (Todate == null)
                    Todate = DateTime.Now;
            }
            var chartDao = new ServiceDao.ChartDao();
            var data = chartDao.getBranchByBranchChartJs(Fromdate.Value,Todate.Value, branchID, Type);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetChartByStore(string fromdate, string toDate, string branchID,string store, int selectType)
        {
            DateTime? Todate = null;
            DateTime? Fromdate = null;
            int Type = selectType;
            try
            {
                switch (selectType)
                {
                    case 1:
                    case 4:
                        Fromdate = DateTime.Parse(fromdate);
                        Todate = DateTime.Parse(toDate);
                        break;
                    case 2:
                        Fromdate = DateTime.Parse(fromdate + "/01");
                        Todate = DateTime.Parse(toDate + "/01");
                        break;
                    case 3:
                        Fromdate = DateTime.Parse(fromdate + "/01");
                        Todate = DateTime.Parse(toDate + "/01");
                        break;
                }
            }
            catch (Exception ex)
            {
                if (Todate == null)
                    Todate = DateTime.Now;
            }
            var chartDao = new ServiceDao.ChartDao();
            var data = chartDao.getBranchByStoreChartJs(Fromdate.Value,Todate.Value, branchID,store, Type);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}