using QuanLyNhanSu.Commons;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Services
{
    public class WebApiCaller
    {
        public string BaseUrl = System.Configuration.ConfigurationSettings.AppSettings["WebUrlAPI"].ToString();
        public String GetUrl(String url)
        {
            var client = new RestClient(BaseUrl+url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            if (HttpContext.Current.Session[SessionKeys.UserLogin] != null)
            {
                request.AddHeader("Authorization","Basic "+ HttpContext.Current.Session[SessionKeys.UserLogin].ToString());
            }
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        public String PostUrl(String url)
        {
            var client = new RestClient(BaseUrl + url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            if (HttpContext.Current.Session[SessionKeys.UserLogin] != null)
            {
                request.AddHeader("Authorization", "Basic " + HttpContext.Current.Session[SessionKeys.UserLogin].ToString());
            }
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}