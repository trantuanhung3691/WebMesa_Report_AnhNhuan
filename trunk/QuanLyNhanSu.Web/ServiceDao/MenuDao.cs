using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.ServiceDao
{
    public class MenuDao
    {
        public List<Navbar> GetMenuBar(string UserName,int Parent=0)
        {
            var url = string.Format("Menu/getMenus?Username={0}&Parent={1}", UserName, Parent);
            var data = new Services.WebApiCaller().GetUrl(url);
            var result = new List<Navbar>();
            var dataJson = JObject.Parse(data)["data"];
            if (dataJson == null)
                return new List<Navbar>();
            foreach(JToken item in dataJson)
            {
                var newItem = new Navbar
                {
                    Id = (int)item["Id"],
                    Action = (string)item["Action"],
                    Class = (string)item["Class"],
                    Controler = (string)item["Controler"],
                    Description = (string)item["Description"],
                    Icon = (string)item["Icon"],
                    Name = (string)item["Name"],
                    Order = item["Order"] == null ? 99 : (int)item["Order"]
                };
                result.Add(newItem);
            }
            return result;
        }
        
    }
}