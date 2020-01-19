using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace QuanLyNhanSu.Web.ServiceDao
{
    public class NhanVienDao
    {
        public String getLogin(string userName,string Password)
        {
            var url = string.Format("User/getLogin?username={0}&password={1}",userName,Password);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"].ToString();
            if (string.IsNullOrEmpty(dataJson))
            {
                return "";
            }
            return dataJson;
        }
        public IEnumerable<Models.NhanVienModel> GetList(String KeyWord)
        {
            var url = string.Format("NhanVien/getList?Keyword={0}",KeyWord);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            IEnumerable<Models.NhanVienModel> result = js.Deserialize<IEnumerable<NhanVienModel>>(dataJson.ToString());
            return result;
        }
        public IEnumerable<Models.NhanVienModel> GetListToCreateUser()
        {
            var url = string.Format("NhanVien/getListToCreateUser");
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            IEnumerable<Models.NhanVienModel> result = js.Deserialize<IEnumerable<NhanVienModel>>(dataJson.ToString());
            return result;
        }
        public Models.NhanVienModel Get(String UserName)
        {
            var url = string.Format("NhanVien/getNhanVien?Username={0}", UserName);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            Models.NhanVienModel result = js.Deserialize<NhanVienModel>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message ChangePassword(UserAdminModel model)
        {
            var url = string.Format("UserAdmin/changePassword?Username={0}&Password={1}", model.Username,model.Password);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message ChangeStatusAccount(int accid,bool value)
        {
            var url = string.Format("UserAdmin/changeStatusAccount?accid={0}&value={1}", accid,value);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Insert(NhanVienModel model,string branchs,string stores)
        {
            var url = string.Format("NhanVien/createNhanVien?Hoten={0}&Email={1}&Dienthoai={2}&Branchs={3}&Stores={4}&Manv={5}", model.HOTEN,model.EMAIL,model.DIENTHOAI,branchs,stores,model.MANV);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Update(NhanVienModel model)
        {
            var url = string.Format("UserAdmin/createNguoiDung?Username={0}", model.HOTEN);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message UpdateThongTinChung(NhanVienModel model)
        {
            var url = string.Format("NhanVien/updateThongTinChung?Manv={0}&Hoten={1}&Email={2}&Dienthoai={3}",model.MANV, model.HOTEN, model.EMAIL, model.DIENTHOAI);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message UpdateProfile(NhanVienModel model)
        {
            var url = string.Format("UserAdmin/createNguoiDung?Username={0}", model.HOTEN);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Delete(string id)
        {
            var url = string.Format("NhanVien/deleteNhanVien?manv={0}", id);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }

        public QuanLyNhanSu.Commons.Message UpdateBranch(string UserName, string  BranchCode,bool value)
        {
            var url = string.Format("NhanVien/updateBranch?UserName={0}&BranchCode={1}&value={2}", UserName, BranchCode,value);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message UpdateStore(string UserName, string StoreCode, bool value)
        {
            var url = string.Format("NhanVien/updateStore?UserName={0}&StoreCode={1}&value={2}", UserName, StoreCode, value);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
    }
}