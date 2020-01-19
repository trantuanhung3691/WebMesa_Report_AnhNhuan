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
    public class NhanVienController : ApiController
    {
        private NhanvienDao accDao = new NhanvienDao();
        [HttpGet]
        [Route("api/NhanVien/getNhanvien")]
        public async Task<HttpResponseMessage> getNhanvien(string UserName)
        {
            try
            {
                var data = accDao.Get(UserName);
                var Jbject = new JObject
                {
                    new JProperty("MANV",data.MANV),
                     new JProperty("HOTEN",data.HOTEN),
                     new JProperty("EMAIL",data.EMAIL),
                     new JProperty("DIENTHOAI",data.DIENTHOAI)
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
        [Route("api/NhanVien/getList")]
        public async Task<HttpResponseMessage> getList(string Keyword)
        {
            try
            {
                var data = accDao.GetList(Keyword).Select(p=>new JObject {
                     new JProperty("MANV",p.MANV),
                     new JProperty("HOTEN",p.HOTEN),
                     new JProperty("EMAIL",p.EMAIL),
                     new JProperty("DIENTHOAI",p.DIENTHOAI),
                }).ToList();
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
        [Route("api/NhanVien/getListToCreateUser")]
        public async Task<HttpResponseMessage> getListToCreateUser()
        {
            try
            {
                var data = accDao.GetListToCreateUser().Select(p => new JObject {
                     new JProperty("MANV",p.MANV),
                     new JProperty("HOTEN",p.HOTEN),
                     new JProperty("EMAIL",p.EMAIL),
                     new JProperty("DIENTHOAI",p.DIENTHOAI),
                }).ToList();
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
        [Route("api/NhanVien/createNhanVien")]
        public async Task<HttpResponseMessage> createNhanVien(string Hoten, string Email, string DienThoai,string Branchs,string Stores,string Manv)
        {
            try
            {
                var nhanvien = new QuanLyNhanSu.Models.VA_W_NHANVIEN
                {
                    MANV=Manv,
                    HOTEN=Hoten,
                    EMAIL=Email,
                    DIENTHOAI=DienThoai
                };
                var data = accDao.Insert(nhanvien,Branchs,Stores);
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
        [Route("api/NhanVien/updateThongTinChung")]
        public async Task<HttpResponseMessage> updateThongTinChung(string Manv,string Hoten, string Email, string DienThoai)
        {
            try
            {
                var nhanvien = new QuanLyNhanSu.Models.VA_W_NHANVIEN
                {
                    MANV=Manv,
                    HOTEN = Hoten,
                    EMAIL = Email,
                    DIENTHOAI = DienThoai
                };
                var data = accDao.Update(nhanvien);
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
        [Route("api/NhanVien/deleteNhanVien")]
        public async Task<HttpResponseMessage> deleteNhanVien(string manv)
        {
            try
            {
                var nhanvien = new QuanLyNhanSu.Models.VA_W_NHANVIEN
                {
                    MANV=manv
                };
                var data = accDao.Delete(nhanvien);
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
        [Route("api/NhanVien/updateBranch")]
        public async Task<HttpResponseMessage> updateBranch(string UserName, string BranchCode, bool value)
        {
            try
            {
                var data = accDao.UpdateBranch(UserName, BranchCode, value);
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
        [Route("api/NhanVien/updateStore")]
        public async Task<HttpResponseMessage> updateStore(string UserName, string StoreCode, bool value)
        {
            try
            {
                var data = accDao.UpdateStore(UserName, StoreCode, value);
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
