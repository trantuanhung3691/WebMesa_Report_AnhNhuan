using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyNhanSu.Web.Areas
{
    public class BaseControler: Controller
    {
        
        public BaseControler()
        {
            
            ViewBag.SuccessMessage = "";
        }
        public void SetTitle()
        {
            var parrar = this.Request.Params.Get("title");
            if (parrar == null)
            {
                var router = RouteData.DataTokens["area"].ToString();
                var cotroler = RouteData.Values["controller"].ToString();
                var action = RouteData.Values["action"].ToString();
                parrar = cotroler;
                switch (action)
                {
                    case "Create":
                        parrar = "Create " + parrar;
                        break;
                    case "Edit":
                        parrar = "Edit " + parrar;
                        break;
                    case "Detail":
                        parrar = "View detail " + parrar;
                        break;
                    case "Delate":
                        parrar = "Remove " + parrar;
                        break;
                }
            }
            ViewBag.Title = parrar;
        }
        //protected override void Initialize(RequestContext requestContext)
        //{
        //    base.Initialize(requestContext);

        //    if (Session[SessionKeys.UserLogin] == null)
        //    {
        //        requestContext.HttpContext.Response.Clear();
        //        requestContext.HttpContext.Response.Redirect("~/Account/Login");
        //        requestContext.HttpContext.Response.End();
        //    }
        //}
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //base.OnActionExecuting();

        //    if (Session[SessionKeys.UserLogin] == null)
        //        filterContext.Result = RedirectToAction("Login", "Account", new { Area = "" });
        //}
    }
}