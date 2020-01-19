using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace QuanLyNhanSu.Web.ServiceDao
{
    public class NgonNguDao
    {
        public List<Models.NgonNguModel> getList()
        {
            var url = string.Format("NgonNgu/getList");
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["data"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.NgonNguModel> result = js.Deserialize<List<NgonNguModel>>(dataJson.ToString());
            return result;
        }
        
    }
}