using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;
using System.Web.WebPages;
namespace QuanLyNhanSu.Web.Utilities
{
    public static class Utilities
    {
        public static string IsActive(this HtmlHelper html,
                                      string control,
                                      string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;

            return returnActive ? "active" : "active";
        }
        public static string IsActiveUl(this HtmlHelper html,
                                      string control,
                                      string action)
        {
            Route route = (Route)html.ViewContext.RouteData.Route;
            var routeData = html.ViewContext.RouteData;
            var bbb = html.ViewContext.RouteData.GetRequiredString("action");
            var url = route.Url;
            // both must match
            var returnActive = url.Split('/').Contains(control);// routeData.Values["id"].ToString() == action;

            return returnActive ? "collapse in" : "";
        }
        public static string IsActiveSubUl(this HtmlHelper html,
                                      string control,
                                      string action)
        {
            // both must match
            var returnActive = control.Contains(action);
            
            return returnActive ? "collapse in" : "";
        }
        public static bool HasPermission(int userID, int GroupID)
        {
            return new QuanLyNhanSu.Web.ServiceDao.UserDao().HasPermissionOnGroup(userID, GroupID);
        }
        
    }
}