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
    public class UserController : ApiController
    {
        private AccountDao accDao = new AccountDao();
        [HttpPost]
        [Route("api/User/getLogin")]
        public async Task<HttpResponseMessage> getLogin(string username, string password)
        {
            try
            {
                var _dePass = Commons.Securitys.CalculateMD5Hash(password);
                var user = accDao.Login(new QuanLyNhanSu.Models.VA_W_UserAdmin { Username = username,MANV=username, Password = _dePass });
                if (user != null)
                {
                    var result = new APIResult(HttpStatusCode.OK);
                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}:{DateTime.Now.AddHours(8).ToString().Replace(":", "_")}")));
                    result.data = authValue.Parameter;
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JObject.FromObject(result).ToString(), Encoding.UTF8, "application/json")
                    };
                }
                else
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JObject.FromObject(new APIResult(HttpStatusCode.Unauthorized, "Fail")).ToString(), Encoding.UTF8, "application/json")
                    };
                }
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
