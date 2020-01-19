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
    public class UserDao
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
        public IEnumerable<Models.UserAdminModel> GetList(String KeyWord)
        {
            var url = string.Format("UserAdmin/getList?Keyword={0}",KeyWord);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            IEnumerable<Models.UserAdminModel> result = js.Deserialize<IEnumerable<UserAdminModel>>(dataJson.ToString());
            return result;
        }

        public Models.UserAdminModel Get(String UserName)
        {
            var url = string.Format("UserAdmin/getAccount?Username={0}", UserName);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            Models.UserAdminModel result = js.Deserialize<UserAdminModel>(dataJson.ToString());
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
        public QuanLyNhanSu.Commons.Message CreateNguoiDung(UserAdminModel model)
        {
            var url = string.Format("UserAdmin/createUser?Username={0}", model.Username);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }


        public bool AccessPermission(string username, string Controler, QuanLyNhanSu.Commons.PermissionCode _perCode)
        {
            var url = string.Format("UserAdmin/accessPermission?username={0}&Controler={1}&_perCode={2}", username,Controler,_perCode);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean result = js.Deserialize<Boolean>(dataJson.ToString());
            return result;
        }
        public bool HasPermissionOnGroup(int UserId, int groupid)
        {
            var url = string.Format("UserAdmin/hasPermissionOnGroup?UserId={0}&groupid={1}", UserId, groupid);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean result = bool.Parse(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message ChangeStatusOnGroup(int usid, int groupid, bool value)
        {
            var url = string.Format("UserAdmin/changeStatusOnGroup?usid={0}&groupid={1}&value={2}", usid,groupid, value);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
    }
}