
using QuanLyNhanSu.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Web.Models;

namespace QuanLyNhanSu.Web.Areas.DanhMuc.Controllers
{
    [Authorize]
    [AuthActionFilter]
    public class NhanVienController : Controller
    {
        // GET: DanhMuc/NHANVIEN
        private readonly QuanLyNhanSu.Web.ServiceDao.NhanVienDao _nvDao = new QuanLyNhanSu.Web.ServiceDao.NhanVienDao();
        public ActionResult Index(string KeyWord="")
        {
            var listNHANVIEN = _nvDao.GetList(KeyWord);
            return View(listNHANVIEN);
        }
        public ActionResult Create()
        {
            var list = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getBranchList();
            var listBranch = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getStoreList("%", "%");
            Session[SessionKeys.StoreList] = listBranch;
            ViewBag.Branchs = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanVienModel model,String lbBranch, String lbStore)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var list = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getBranchList();
            var listBranch = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getStoreList("%", "%");
            Session[SessionKeys.StoreList] = listBranch;
            ViewBag.Branchs = list;
            var msg = _nvDao.Insert(model,lbBranch,lbStore);
            if (msg._msgType == Commons.MessageType.Success)
            {
                ViewBag.SuccessMessage = msg._strDescription;
                return View(model);
            }
            else
            {
                ViewBag.ErrorMessage = msg._strDescription;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return View("Home");
            id = id.Replace(Commons.StringCommons.ParametterDot, ".");
            var NHANVIEN = _nvDao.Get(id);
            var list = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getBranchUserList(NHANVIEN.MANV);
            var listBranch = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getStoreList("%",NHANVIEN.MANV);
            Session[SessionKeys.StoreList] = listBranch;
            ViewBag.Branchs = list;
            SetViewBags(id);
            return View(NHANVIEN);
        }
        [HttpPost]
        public ActionResult Edit(NhanVienModel model,string submit)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var list = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getBranchUserList(model.MANV);
            var listBranch = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getStoreList("%", model.MANV);
            Session[SessionKeys.StoreList] = listBranch;
            ViewBag.Branchs = list;
            var _msg = _nvDao.Update(model);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                var NHANVIEN = _nvDao.Get(model.MANV);
                return View(NHANVIEN);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditThongTinChung(NhanVienModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var list = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getBranchUserList(model.MANV);
            var listBranch = new QuanLyNhanSu.Web.ServiceDao.StoreDao().getStoreList("%", model.MANV);
            Session[SessionKeys.StoreList] = listBranch;
            ViewBag.Branchs = list;
            var _msg = _nvDao.UpdateThongTinChung(model);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                var NHANVIEN = _nvDao.Get(model.MANV);
                ViewBag.SuccessMessage = _msg._strDescription;
                SetViewBags(model.MANV);
                return View("Edit", NHANVIEN);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProfile(NhanVienModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //SetViewBags(model.MANV);
            var _msg = _nvDao.UpdateProfile(model);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                var NHANVIEN = _nvDao.Get(model.MANV);
                SetViewBags(model.MANV);
                return View("Edit", NHANVIEN);
            }
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            id = id.Replace(Commons.StringCommons.ParametterDot, ".");
            var _msg = _nvDao.Delete(id);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                return RedirectToAction("Index", "NHANVIEN");
            }
            return RedirectToAction("Index", "NHANVIEN");
        }
        [HttpPost]
        public ActionResult UpdatePermission(string BranchCode, string UserName, bool value)
        {
            var msg = _nvDao.UpdateBranch( UserName,BranchCode,value);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateStorePermission(string storecode, string UserName, bool value)
        {
            var msg = _nvDao.UpdateStore(UserName, storecode, value);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public void SetViewBags(string manv)
        {
            ViewBag.MANV = manv;
        }
    }
}