using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
namespace QuanLyNhanSu.Web.Api.Controllers
{
    [Authorize]
    public class MenuController : ApiController
    {
        [HttpGet]
        [Route("api/Menu/getMenus")]
        public async Task<HttpResponseMessage> getMenus(String Username,int Parent=0)
        {
            MenuDao mnDao = new MenuDao();
            try
            {
                var data = mnDao.GetMenuBar(Username, Parent);
                var result=new APIResult(HttpStatusCode.OK);
                result.data = data;
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
