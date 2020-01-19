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
    public class UserAdminController : ApiController
    {
        private AccountDao accDao = new AccountDao();
        [HttpGet]
        [Route("api/UserAdmin/getAccount")]
        public async Task<HttpResponseMessage> getAccount(string UserName)
        {
            try
            {
                var data = accDao.Get(UserName);
                var Jbject = new JObject
                {
                    new JProperty("Active",data.Active),
                    new JProperty("CreateBy",data.CreateBy),
                    new JProperty("CreateDate",data.CreateDate),
                    new JProperty("Deleted",data.Deleted),
                    new JProperty("Id",data.Id),
                    new JProperty("MANV",data.MANV),
                    new JProperty("UpdateBy",data.UpdateBy),
                    new JProperty("UpdateDate",data.UpdateDate),
                    new JProperty("Username",data.Username),
                    new JProperty("Password",data.Password)
                };
                var result = new APIResult(HttpStatusCode.OK);
                result.data = Jbject;
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

        [HttpGet]
        [Route("api/UserAdmin/hasPermissionOnGroup")]
        public async Task<HttpResponseMessage> hasPermissionOnGroup(int UserId, int groupid)
        {
            try
            {
                var data = accDao.HasPermissionOnGroup(UserId, groupid);
                var result = new APIResult(HttpStatusCode.OK);
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
        [HttpPost]
        [Route("api/UserAdmin/createUser")]
        public async Task<HttpResponseMessage> createUser(string UserName)
        {
            try
            {
                var UserAdmin = new QuanLyNhanSu.Models.VA_W_UserAdmin
                {
                    MANV=UserName,
                    Username = UserName,
                    CreateBy = User.Identity.Name,
                    UpdateBy = User.Identity.Name
                };
                var data = accDao.CreateNguoiDung(UserAdmin);
                var result = new APIResult(HttpStatusCode.OK);
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
        [HttpGet]
        [Route("api/UserAdmin/getList")]
        public async Task<HttpResponseMessage> getList(string Keyword="")
        {
            try
            {
                var data = accDao.GetList(Keyword).ToList();
                var result = new APIResult(HttpStatusCode.OK);
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
        [HttpPost]
        [Route("api/UserAdmin/changeStatusOnGroup")]
        public async Task<HttpResponseMessage> changeStatusOnGroup(int usid, int groupid, bool value)
        {
            try
            {
                var data = accDao.ChangeStatusOnGroup(groupid, usid, value);
                var result = new APIResult(HttpStatusCode.OK);
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
        [HttpPost]
        [Route("api/UserAdmin/changeStatusAccount")]
        public async Task<HttpResponseMessage> changeStatusAccount(int accid, bool value)
        {
            try
            {
                var data = accDao.ChangeStatusAccount(accid,value);
                var result = new APIResult(HttpStatusCode.OK);
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
        [HttpPost]
        [Route("api/UserAdmin/changePassword")]
        public async Task<HttpResponseMessage> changePassword(string Username, string Password)
        {
            try
            {
                var user = new QuanLyNhanSu.Models.VA_W_UserAdmin
                {
                    MANV=Username,
                    Username=Username,
                    Password=Password
                };
                var data = accDao.ChangePassword(user);
                var result = new APIResult(HttpStatusCode.OK);
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
        [HttpPost]
        [Route("api/UserAdmin/accessPermission")]
        public async Task<HttpResponseMessage> accessPermission(string username, string Controler, QuanLyNhanSu.Commons.PermissionCode _perCode)
        {
            try
            {
                var data = accDao.AccessPermission(username, Controler, _perCode);
                var result = new APIResult(HttpStatusCode.OK);
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
