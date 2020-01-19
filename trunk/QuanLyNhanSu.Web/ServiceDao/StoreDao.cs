using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace QuanLyNhanSu.Web.ServiceDao
{
    public class StoreDao
    {
        public List<Models.StoreModel> getList(string keyword)
        {
            var url = string.Format("Store/getNames?NameGroup={0}", keyword);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<Models.StoreModel>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new StoreModel
                {
                    ID=(string)item["ID"],
                    Name=(string)item["Name"],
                    STT=(int)item["STT"]
                };
                result.Add(dataItem);
            }
            return result;
        }
        public List<Models.StoreModel> getStoreList(string branch,string username)
        {
            var url = string.Format("Store/getStoreListByBranch?branch={0}&UserName={1}", branch, username);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<Models.StoreModel>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new StoreModel
                {
                    ID = (string)item["ID"],
                    Name = (string)item["Name"],
                    STT = (int)item["STT"]
                };
                var isUsed = (int) item["IsUsed"];
                dataItem.IsUsed = isUsed > 0;
                result.Add(dataItem);
            }
            return result;
        }
        public List<Models.BranchModel> getBranchList()
        {
            var url = string.Format("Store/getBranchList");
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.BranchModel> result = js.Deserialize<List<BranchModel>>(dataJson.ToString());
            return result;
        }
        public List<Models.BranchUserModel> getBranchUserList(string UserName)
        {
            var url = string.Format("Store/getBranchUsers?UserName={0}", UserName);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.BranchUserModel> result = js.Deserialize<List<BranchUserModel>>(dataJson.ToString());
            return result;
        }
        public List<Models.BranchUserModel> getBranchManage()
        {
            var url = string.Format("Store/getBranchManage");
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.BranchUserModel> result = js.Deserialize<List<BranchUserModel>>(dataJson.ToString());
            return result;
        }

        public IEnumerable<Models.StoreModel> Search(String KeyWord)
        {
            var url = string.Format("Store/getStores?Keyword={0}", KeyWord);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            IEnumerable<Models.StoreModel> result = js.Deserialize<IEnumerable<StoreModel>>(dataJson.ToString());
            return result;
        }
        public Models.StoreModel Get(string id)
        {
            var url = string.Format("Store/getStore?Storecode={0}", id);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            Models.StoreModel result = js.Deserialize<StoreModel>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Insert(StoreModel model)
        {
            var url = string.Format("Store/createStore?StoreID={0}&StoreName={1}&Note={2}&STT={3}", model.ID, model.Name, model.Note,model.STT);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Update(StoreModel model)
        {
            var url = string.Format("Store/updateStore?StoreID={0}&StoreName={1}&Note={2}&STT={3}", model.ID, model.Name, model.Note, model.STT);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Delete(string id)
        {
            var url = string.Format("Store/deleteStore?StoreID={0}", id);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
    }
}