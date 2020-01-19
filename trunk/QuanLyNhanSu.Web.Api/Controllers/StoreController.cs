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
    public class StoreController : ApiController
    {
        private QuanLyNhanSu.Dao.StoriesDao dao = new QuanLyNhanSu.Dao.StoriesDao();
        [HttpGet]
        [Route("api/Store/getStores")]
        public async Task<HttpResponseMessage> getStores(string keyword)
        {
            try
            {
                
                var list = dao.GetList(keyword).ToList().Select(x=>new Models.StoreModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    NameGroup = x.NameGroup,
                    Note = x.Note,
                    STT = x.STT.HasValue?x.STT.Value:0,
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
        [HttpGet]
        [Route("api/Store/getBranchList")]
        public async Task<HttpResponseMessage> getBranchList()
        {
            try
            {
                var list = dao.GetBranchs();
                var result = new APIResult(HttpStatusCode.OK);
                result.data = list;
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
        [Route("api/Store/getStoreListByBranch")]
        public async Task<HttpResponseMessage> getStoreListByBranch(string branch,string UserName)
        {
            try
            {
                ReportClass rpClass = new ReportClass();
                var dts = rpClass.FC_W_GetNameByBranch(string.IsNullOrEmpty(branch) ? "%" : branch, UserName);
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
        [Route("api/Store/getBranchUsers")]
        public async Task<HttpResponseMessage> getBranchUsers(string UserName)
        {
            try
            {
                var user = new Dao.AccountDao().Get(UserName);
                var list = dao.GetBranchUsers(UserName);
                var result = new APIResult(HttpStatusCode.OK);
                result.data = list;
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
        [Route("api/Store/getNames")]
        public async Task<HttpResponseMessage> getNames(string NameGroup)
        {
            ReportClass rpClass = new ReportClass();
            try
            {
                var username = User.Identity.Name;
                var dts = rpClass.FC_W_GetNameByCode(string.IsNullOrEmpty(NameGroup) ? "%" : NameGroup,username);
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
        [Route("api/Store/getBranchManage")]
        public async Task<HttpResponseMessage> getBranchManage()
        {
            StoriesDao stDao = new StoriesDao();
            try
            {
                var username = User.Identity.Name;
                var dts = stDao.GetBranchManaged(username);
                var result = new APIResult(HttpStatusCode.OK);
                result.data = dts;
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
        [Route("api/Store/getStore")]
        public async Task<HttpResponseMessage> getStore(string Storecode)
        {
            try
            {
                var data = dao.Get(Storecode);
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
        [Route("api/Store/createStore")]
        public async Task<HttpResponseMessage> createStore(string StoreID, string StoreName,string Note,int STT)
        {
            try
            {
                var store = new QuanLyNhanSu.Models.VA_NAME
                {
                    ID = StoreID,
                    Name = StoreName,
                    Note = Note,
                    STT=STT,
                    NameGroup= "STORE"
                };
                var data = dao.Insert(store);
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
        [Route("api/Store/updateStore")]
        public async Task<HttpResponseMessage> updateStore(string StoreID, string StoreName, string Note, int STT)
        {
            try
            {
                var group = new QuanLyNhanSu.Models.VA_NAME
                {
                    ID = StoreID,
                    Name=StoreName,
                    STT=STT,
                    Note=Note,
                    NameGroup="STORE"
                };
                var data = dao.Update(group);
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
        [Route("api/Store/deleteStore")]
        public async Task<HttpResponseMessage> deleteStore(string StoreID)
        {
            try
            {
                var gr = dao.Get(StoreID);
                var data = dao.Delete(gr);
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
