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
    public class GroupDao
    {
        
        public IEnumerable<Models.GroupModel> GetList(String KeyWord)
        {
            var url = string.Format("Group/getList?Keyword={0}",KeyWord);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            IEnumerable<Models.GroupModel> result = js.Deserialize<IEnumerable<GroupModel>>(dataJson.ToString());
            return result;
        }
        public IEnumerable<Models.GroupFuctionDetail> GetDetail(int id)
        {
            var url = string.Format("Group/getDetail?grID={0}", id);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            IEnumerable<Models.GroupFuctionDetail> result = js.Deserialize<IEnumerable<GroupFuctionDetail>>(dataJson.ToString());
            return result;
        }
        public Models.GroupModel Get(int id)
        {
            var url = string.Format("Group/getGroup?id={0}", id);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            Models.GroupModel result = js.Deserialize<GroupModel>(dataJson.ToString());
            return result;
        }
        
        
        public QuanLyNhanSu.Commons.Message Insert(GroupModel model)
        {
            var url = string.Format("Group/createGroup?Groupname={0}&Description={1}", model.Name,model.Description);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Update(GroupModel model)
        {
            var url = string.Format("Group/updateGroup?id={0}&groupname={1}&description={2}", model.Id, model.Name, model.Description);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message UpdatePermission(int grID, int FunctionID, int Mash, bool value)
        {
            var url = string.Format("Group/updatePermission?grID={0}&FunctionID={1}&Mash={2}&value={3}", grID,FunctionID,Mash,value);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message UpdatePermissionAll(int GroupID, int Per, bool value)
        {
            var url = string.Format("Group/updatePermissionAll?GroupID={0}&Per={1}&value={2}", GroupID, Per,value);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Delete(int id)
        {
            var url = string.Format("Group/deleteGroup?id={0}", id);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
    }
}