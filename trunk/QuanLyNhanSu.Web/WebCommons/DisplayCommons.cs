using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace QuanLyNhanSu.Web.WebCommons
{
    public class DisplayCommons
    {
        public static String StoreName(string StoreID)
        {
            if (StoreID == "" || StoreID == "%")
                return "All Store";
            var dic = HttpContext.Current.Session[Commons.SessionKeys.Store] as Dictionary<string, string>;
            if (dic == null)
            {
                // set seesion 
                var stores = new ServiceDao.StoreDao().getList("STORE");
                Dictionary<String, String> dicStores = new Dictionary<string, string>();
                foreach (var item in stores)
                {
                    dicStores.Add(item.ID, item.Name);
                }
                HttpContext.Current.Session[Commons.SessionKeys.Store] = dicStores;
                return dicStores[StoreID].ToString();
            }   
            else
            {
                if (StoreID.Contains(","))
                {
                    var result = "";
                    var arrStoreIDs = StoreID.Split(',');
                    foreach (var id in arrStoreIDs)
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            result += (result.Equals("") ? dic[id].ToString() : (","+dic[id].ToString()));
                        }
                    }
                    return result;
                }
                if (dic[StoreID] == null) return "";
                return dic[StoreID].ToString();
            }
        }
        public static List<Models.LogoReportModel> ListLogo(string StoreIDs)
        {
            var arrStore = StoreIDs.Split(',').Select(p=>p.Substring(0,2));
            var branhs = HttpContext.Current.Session[Commons.SessionKeys.BranchList] as List<Models.BranchUserModel>;
            if (branhs != null)
            {
                var result = new List<Models.LogoReportModel>();
                foreach (var item in branhs)
                {
                    if (arrStore.Contains(item.BRANCHCODE))
                    {
                        var pat = new Uri(HttpContext.Current.Server.MapPath(item.BRANCHLOGO)).AbsoluteUri;
                        result.Add(new Models.LogoReportModel { Path = pat });
                    }
                }
                return result;
            }
            else
                return null;
        }
    }
}