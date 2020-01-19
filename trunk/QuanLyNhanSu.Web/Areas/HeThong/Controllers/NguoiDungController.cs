using Microsoft.Owin.Security;
using QuanLyNhanSu.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.Areas.HeThong.Controllers
{
    [AuthActionFilter]
    [Authorize]
    public class NguoiDungController : Controller
    {
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        // GET: HeThong/NguoiDung
        private readonly QuanLyNhanSu.Web.ServiceDao.UserDao _ndDao = new QuanLyNhanSu.Web.ServiceDao.UserDao();
        private readonly QuanLyNhanSu.Web.ServiceDao.GroupDao _grDao = new ServiceDao.GroupDao();
        public ActionResult Index(string KeyWord)
        {
            var listUser = _ndDao.GetList(KeyWord);
            return View(listUser);
        }

        public ActionResult ChangePassword()
        {
            var user = _ndDao.Get(User.Identity.Name);
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangePassword(string Password,string NewPassword,string NewPasswordAgain)
        {
            var user = _ndDao.Get(User.Identity.Name);
            if (!NewPassword.Equals(NewPasswordAgain))
            {
                ViewBag.ErrorMessage = "Mật khẩu gõ lại không khớp";
            }
            else if (!user.Password.Equals(Commons.Securitys.CalculateMD5Hash(Password)))
            {
                ViewBag.ErrorMessage = "Mật khẩu cũ không khớp";
            }
            else if (NewPassword.Length < 6)
            {
                ViewBag.ErrorMessage = "Mật khẩu không được dưới 6 ký tự";
            }
            else
            {
                user.Password = Commons.Securitys.CalculateMD5Hash(NewPasswordAgain);
                var msg = _ndDao.ChangePassword(user);
                if (msg._msgType != Commons.MessageType.Success)
                {
                    ViewBag.ErrorMessage = "Cập nhật không thành công";
                }
                else
                {
                    Session.Clear();
                    Authentication.SignOut();
                    return RedirectToAction("Index", "NguoiDung");// ("NguoiDung", "",new { Areas = "" });
                }
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangeStatus(int accid, bool value)
        {
            var msg = _ndDao.ChangeStatusAccount(accid, value);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateNguoiDung(QuanLyNhanSu.Web.Models.UserAdminModel userAdmin)
        {
            userAdmin.Username = userAdmin.MANV;
            var msg = _ndDao.CreateNguoiDung(userAdmin);
            return RedirectToAction("Index", "NguoiDung");
        }
        public ActionResult Permission(int id,string KeyWord)
        {
            if (id == null) id = 0;
            ViewBag.UserID = id;
            var groups = _grDao.GetList(KeyWord!=null?KeyWord:"");
            return View(groups);
        }
        [HttpPost]
        public ActionResult ChangeStatusPermission(int usid,int groupid, bool value)
        {
            var msg = _ndDao.ChangeStatusOnGroup(usid,groupid, value);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ResetPassword(string usid)
        {
            var user = _ndDao.Get(usid);
            user.Password = Commons.Securitys.CalculateMD5Hash(Commons.StringCommons.PwDefault);
            var msg = _ndDao.ChangePassword(user);
            return Json(msg, JsonRequestBehavior.AllowGet);
            
        }
    }
}