using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuanLyNhanSu.Web.Api.Controllers
{
    public class DefaultController : ApiController
    {
        private ReportClass rpClass = new ReportClass();
        [Route("api/Default/GetConsolidationReport")]
        public async Task<HttpResponseMessage> GetConsolidationReport(string storeid, string _fromdate, string _todate)
        {
            try
            {
                DateTime? fromdate = DateTime.Parse(_fromdate);
                DateTime? todate = DateTime.Parse(_todate);
                var dts = rpClass.RP_Consolidation(fromdate.Value, todate.Value, storeid);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(dts.Tables[0]).ToString(), Encoding.UTF8, "application/json")
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
