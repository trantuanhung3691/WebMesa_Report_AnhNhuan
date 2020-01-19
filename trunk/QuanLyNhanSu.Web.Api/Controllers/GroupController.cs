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
    public class GroupController : ApiController
    {
        private GroupDao groupDao = new GroupDao();
        [HttpGet]
        [Route("api/Group/getGroup")]
        public async Task<HttpResponseMessage> getGroup(int id)
        {
            try
            {
                var data = groupDao.Get(id);
                var Jbject = new JObject
                {
                     new JProperty("Id",data.Id),
                    new JProperty("Active",data.Active),
                    new JProperty("CreateBy",data.CreateBy),
                    new JProperty("UpdateBy",data.UpdateBy),
                     new JProperty("UpdateDate",data.UpdateDate),
                    new JProperty("CreateDate",data.CreateDate),
                    new JProperty("Deleted",data.Deleted),
                    new JProperty("Description",data.Description),
                    new JProperty("Name",data.Name)
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
        [Route("api/Group/getList")]
        public async Task<HttpResponseMessage> getList(string Keyword)
        {
            try
            {
                var list = groupDao.GetList(Keyword).Select(data => new JObject {
                     new JProperty("Id",data.Id),
                    new JProperty("Active",data.Active),
                    new JProperty("CreateBy",data.CreateBy),
                    new JProperty("UpdateBy",data.UpdateBy),
                     new JProperty("UpdateDate",data.UpdateDate),
                    new JProperty("CreateDate",data.CreateDate),
                    new JProperty("Deleted",data.Deleted),
                    new JProperty("Description",data.Description),
                    new JProperty("Name",data.Name)
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
        [Route("api/Group/createGroup")]
        public async Task<HttpResponseMessage> createGroup(string Groupname,string Description)
        {
            try
            {
                var nhanvien = new QuanLyNhanSu.Models.VA_W_Group
                {
                    Name=Groupname,
                    Description= Description,
                    Active=true,
                    Deleted=false,
                    CreateBy=User.Identity.Name,
                    UpdateBy=User.Identity.Name,
                    CreateDate=DateTime.Now,
                    UpdateDate=DateTime.Now
                };
                var data = groupDao.Insert(nhanvien);
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
        [Route("api/Group/updateGroup")]
        public async Task<HttpResponseMessage> updateGroup(int id,string groupname,string description)
        {
            try
            {
                var group = new QuanLyNhanSu.Models.VA_W_Group
                {
                    Id=id,
                    Name=groupname,
                    Description=description,
                    UpdateBy=User.Identity.Name,
                    UpdateDate=DateTime.Now
                };
                var data = groupDao.Update(group);
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
        [Route("api/Group/deleteGroup")]
        public async Task<HttpResponseMessage> deleteGroup(int id)
        {
            try
            {
                var gr = groupDao.Get(id);
                var data = groupDao.Delete(gr);
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
        [Route("api/Group/updatePermission")]
        public async Task<HttpResponseMessage> updatePermission(int grID, int FunctionID, int Mash, bool value)
        {
            try
            {
                var data = groupDao.UpdatePermission(grID,FunctionID,Mash,value,User.Identity.Name);
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
        [Route("api/Group/updatePermissionAll")]
        //Group/updatePermissionAll? GroupID = 18 & Per = 1 & value = True
        public async Task<HttpResponseMessage> updatePermissionAll(int GroupID, int Per, bool value)
        {
            try
            {
                var data = groupDao.UpdatePermissionAll(GroupID, Per, value, User.Identity.Name);
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
        [Route("api/Group/getDetail")]
        public async Task<HttpResponseMessage> getDetail(int grID)
        {
            try
            {
                var data = groupDao.GetDetail(grID);
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
