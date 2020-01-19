using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuanLyNhanSu.Web.Api.Controllers
{
    [Authorize]
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("api/Report/getConsolidationReport")]
        public async Task<HttpResponseMessage> getConsolidationReport(string storeid,string _fromdate,string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_Consolidation(fromdate.Value, todate.Value, storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
        [HttpGet]
        [Route("api/Report/getTender")]
        public async Task<HttpResponseMessage> getTender(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {

                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_Tender(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid)?"%":storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
        [HttpGet]
        [Route("api/Report/getWeeklyHourly")]
        public async Task<HttpResponseMessage> getWeeklyHourly(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_WeeklyHourlyReport(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid) ? "%" : storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet]
        [Route("api/Report/RP_W_WeeklyHourlySaleReport")]
        public async Task<HttpResponseMessage> RP_W_WeeklyHourlySaleReport(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_WeeklyHourlySaleReport(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid) ? "%" : storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
        [HttpGet]
        [Route("api/Report/getLossPreventionReport")]
        public async Task<HttpResponseMessage> getLossPreventionReport(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_LossPreventionReport(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid) ? "%" : storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet]
        [Route("api/Report/getItemSaleReport")]
        public async Task<HttpResponseMessage> getItemSaleReport(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_ItemSaleReport(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid) ? "%" : storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
        [HttpGet]
        [Route("api/Report/getItemSaleByDesReport")]
        public async Task<HttpResponseMessage> getItemSaleByDesReport(string storeid, string _fromdate, string _todate,string _keyword, string _condition)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                _keyword = string.IsNullOrEmpty(_keyword) ? "" : _keyword;
                //_condition = _condition == "Choose one condition" ? "" : _condition;
                var dts = rpClass.RP_W_ItemSaleByDesReport(fromdate.Value, todate.Value, (string.IsNullOrEmpty(storeid) ? "%" : storeid),_keyword, _condition);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
        [HttpGet]
        [Route("api/Report/getItemSaleByItemReport")]
        public async Task<HttpResponseMessage> getItemSaleByItemReport(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_ItemSaleByItemReport(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid) ? "%" : storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
        [HttpGet]
        [Route("api/Report/getItemSaleByTenderReport")]
        public async Task<HttpResponseMessage> getItemSaleByTenderReport(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_ItemSaleByTenderReport(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid) ? "%" : storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [Route("api/Report/getDiscountByCodeReport")]
        public async Task<HttpResponseMessage> getDiscountByCodeReport(string storeid, string _fromdate, string _todate)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_DiscountByCodeReport(fromdate.Value, todate.Value, string.IsNullOrEmpty(storeid) ? "%" : storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpGet]
        [Route("api/Report/getChartBranchsReport")]
        public async Task<HttpResponseMessage> getChartBranchsReport(string branchs, string _fromdate, string _todate,int type)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_ChartBranchs(fromdate.Value, todate.Value, branchs,type,User.Identity.Name);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet]
        [Route("api/Report/getChartByBranchsReport")]
        public async Task<HttpResponseMessage> getChartByBranchsReport(string branchs, string _fromdate, string _todate, int type)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_ChartByBranchs(fromdate.Value, todate.Value, branchs, type,User.Identity.Name);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet]
        [Route("api/Report/getChartByStoreReport")]
        public async Task<HttpResponseMessage> getChartByStoreReport(string branchs,string store,string _fromdate, string _todate, int type)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                DateTime? frmdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_W_ChartByStore(frmdate.Value,todate.Value, branchs,store, type);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts).ToString(), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ExpectationFailed,
                    Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.ExpectationFailed)).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }


    }
}
