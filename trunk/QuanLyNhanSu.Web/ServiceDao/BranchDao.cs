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
    public class BranchDao
    {
        
        public IEnumerable<Models.BranchModel> GetList(String KeyWord)
        {
            var url = string.Format("Branch/getBranchs?Keyword={0}", KeyWord);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            IEnumerable<Models.BranchModel> result = js.Deserialize<IEnumerable<BranchModel>>(dataJson.ToString());
            return result;
        }
        public Models.BranchModel Get(string id)
        {
            var url = string.Format("Branch/getBranch?Branchcode={0}", id);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            Models.BranchModel result = js.Deserialize<BranchModel>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Insert(BranchModel model)
        {
            var url = string.Format("Branch/createBranch?Branchcode={0}&Branchname={1}&Branchlogo={2}", model.BRANCHCODE,model.BRANCHNAME,model.BRANCHLOGO);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Update(BranchModel model)
        {
            var url = string.Format("Branch/updateBranch?Branchcode={0}&Branchname={1}&Branchlogo={2}", model.BRANCHCODE, model.BRANCHNAME, model.BRANCHLOGO);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
        public QuanLyNhanSu.Commons.Message Delete(string id)
        {
            var url = string.Format("Branch/deleteBranch?Branchcode={0}", id);
            var data = new Services.WebApiCaller().PostUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            QuanLyNhanSu.Commons.Message result = js.Deserialize<QuanLyNhanSu.Commons.Message>(dataJson.ToString());
            return result;
        }
    }
}