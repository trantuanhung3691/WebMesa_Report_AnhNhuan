using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Dao;

namespace QuanLyNhanSu.Web.Api.Controllers
{
    [Authorize]
    public class NgonNguController : ApiController
    {
        private QuanLyNhanSu.Dao.VA_W_NGONNGUDao dao = new QuanLyNhanSu.Dao.VA_W_NGONNGUDao();
        [HttpGet]
        [Route("api/NgonNgu/getList")]
        public async Task<HttpResponseMessage> getList()
        {
            try
            {
                var list = dao.GetList().ToList().Select(x=>new JObject
                {
                    new JProperty("ColumnName",x.ColumnName),
                    new JProperty("TiengViet",x.TiengViet),
                    new JProperty("TiengAnh",x.TiengAnh),
                });
                var result = new APIResult(HttpStatusCode.OK);
                result.data = list ;
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JObject.FromObject(result).ToString(), Encoding.UTF8, "application/json")
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
