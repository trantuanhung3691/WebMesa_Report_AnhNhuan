using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using QuanLyNhanSu.Web.Filters;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace QuanLyNhanSu.Web.Controllers
{
   
    public class AccountController : Controller
    {       
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var checkLogin = new ServiceDao.UserDao().getLogin(model.UserName, model.Password);

            //var _accDao = new AccountDao();
            //var _dePass = Commons.Securitys.CalculateMD5Hash(model.Password);
            //var userLogin = _accDao.Login(model.UserName, _dePass);
            if (!string.IsNullOrEmpty(checkLogin) && checkLogin!= "Fail")
            {
                Session[Commons.SessionKeys.UserLogin] = checkLogin;
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                // set seesion 
                var stores = new ServiceDao.StoreDao().getList("STORE");
                Dictionary<String, String> dicStores = new Dictionary<string, string>();
                foreach(var item in stores)
                {
                    dicStores.Add(item.ID, item.Name);
                }
                Session[Commons.SessionKeys.Store] = dicStores;
                // load Ngon Ngu
                var ngonngus = new ServiceDao.NgonNguDao().getList();
                Dictionary<string, string> dicNgonNgu = new Dictionary<string, string>();
                foreach(var item in ngonngus)
                {
                    if (dicNgonNgu.ContainsKey(item.ColumnName))
                        continue;
                    switch (Commons.CONFIGVALUE.NgonNgu)
                    {
                        case 1:
                            dicNgonNgu.Add(item.ColumnName, item.TiengViet);
                            break;
                        case 2:
                            dicNgonNgu.Add(item.ColumnName, item.TiengAnh);
                            break;
                        case 3:
                            dicNgonNgu.Add(item.ColumnName, item.TiengViet);
                            break;
                    }
                }
                var branchs = new ServiceDao.StoreDao().getBranchManage();
                Session[Commons.SessionKeys.NgonNgu] = dicNgonNgu;
                Session[Commons.SessionKeys.BranchList] = branchs;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear();
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
       
    }
}