using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace QuanLyNhanSu.Web.Filters
{
    public class AuthActionFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private ServiceDao.UserDao accDao = new ServiceDao.UserDao();
        public void OnAuthentication(AuthenticationContext filterContext)
        {
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
       {

            string userName = null;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                userName = filterContext.HttpContext.User.Identity.Name;
            }
            if(HttpContext.Current.Session[SessionKeys.UserLogin]==null)
            {
                HttpContext.Current.Session.Clear();
                userName = null;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login", area = "" }));
                return;
            }
            try
            {
                if (!Access(filterContext.RouteData, userName))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Denie",area = "" }));
                    //filterContext.Result = new HttpUnauthorizedResult();
                }
                base.OnActionExecuting(filterContext);
            }
            catch
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

        }

        private bool Access(RouteData routeData, string userName)
        {
            var controllerName = routeData.Values["controller"].ToString();
            var actionName = routeData.Values["action"].ToString();
            var Tokens = routeData.DataTokens;
            PermissionCode code = PermissionCode.View;
            switch (actionName)
            {
                case "Index":
                    code = PermissionCode.View;
                    break;
                case "Create":
                    code = PermissionCode.Create;
                    break;
                case "Delete":
                    code = PermissionCode.Delete;
                    break;
                case "Edit":
                case "Details":
                case "Update":
                    code = PermissionCode.Edit;
                    break;
            }
            if(actionName== "ChangePassword")
            {
                return true;
            }
            if (userName == HttpContext.Current.User.Identity.Name)
            {
                return true;
            }
            if (!string.IsNullOrEmpty(userName) && controllerName == "Home" && actionName == "Index") return true;
            var ControllerMain = Tokens.Values.Count >= 3 ? Tokens["area"].ToString() : "";
            ControllerMain ="/"+ ControllerMain + "/" + controllerName;
            var access = accDao.AccessPermission(userName, ControllerMain, code);
            var context = new ActionExecutingContext();
            return access;
        }
    }
}