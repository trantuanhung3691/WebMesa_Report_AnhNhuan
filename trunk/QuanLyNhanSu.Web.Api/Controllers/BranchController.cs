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
    public class BranchController : ApiController
    {
        private BranchDao branchDao = new BranchDao();
        [HttpGet]
        [Route("api/Branch/getBranch")]
        public async Task<HttpResponseMessage> getBranch(string Branchcode)
        {
            try
            {
                var data = branchDao.Get(Branchcode);
                var Jbject = new JObject
                {
                    new JProperty("BRANCHCODE",data.BRANCHCODE),
                    new JProperty("BRANCHLOGO",data.BRANCHLOGO),
                    new JProperty("BRANCHNAME",data.BRANCHNAME)
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
        [Route("api/Branch/getBranchs")]
        public async Task<HttpResponseMessage> getBranchs(string Keyword)
        {
            try
            {
                var list = branchDao.GetList(Keyword).Select(data => new JObject {
                    new JProperty("BRANCHCODE",data.BRANCHCODE),
                    new JProperty("BRANCHLOGO",data.BRANCHLOGO),
                    new JProperty("BRANCHNAME",data.BRANCHNAME)
                }).ToList();
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
        [HttpPost]
        [Route("api/Branch/createBranch")]
        public async Task<HttpResponseMessage> createBranch(string Branchname, string Branchcode,string Branchlogo)
        {
            try
            {
                var nhanvien = new QuanLyNhanSu.Models.VA_W_BRANCH
                {
                    BRANCHNAME=Branchname,
                    BRANCHCODE=Branchcode,
                    BRANCHLOGO=Branchlogo
                };
                var data = branchDao.Insert(nhanvien);
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
        [Route("api/Branch/updateBranch")]
        public async Task<HttpResponseMessage> updateBranch(string Branchcode, string Branchname, string Branchlogo)
        {
            try
            {
                var group = new QuanLyNhanSu.Models.VA_W_BRANCH
                {
                    BRANCHCODE=Branchcode,
                    BRANCHLOGO=Branchlogo,
                    BRANCHNAME=Branchname
                };
                var data = branchDao.Update(group);
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
        [Route("api/Branch/deleteBranch")]
        public async Task<HttpResponseMessage> deleteBranch(string Branchcode)
        {
            try
            {
                var gr = branchDao.Get(Branchcode);
                var data = branchDao.Delete(gr);
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
