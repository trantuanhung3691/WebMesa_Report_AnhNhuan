using QuanLyNhanSu.Web.Filters;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.Areas.DanhMuc.Controllers
{
    [AuthActionFilter]
    [Authorize]
    public class StoreController : BaseControler
    {
        // GET: DanhMuc/Branch
        QuanLyNhanSu.Web.ServiceDao.StoreDao storeDao = new ServiceDao.StoreDao();
        public ActionResult Index(string KeyWord = "")
        {
            var _groups = storeDao.Search(KeyWord);
            return View(_groups);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetTitle();
            return View();
        }
        [HttpPost]
        public ActionResult Create(StoreModel model)
        {
            SetTitle();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var msg = storeDao.Insert(model);
            if (msg._msgType == Commons.MessageType.Success)
            {
                ViewBag.SuccessMessage = msg._strDescription;
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            SetTitle();
            return View(storeDao.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(StoreModel model)
        {
            SetTitle();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var _msg = storeDao.Update(model);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                ViewBag.SuccessMessage = _msg._strDescription;
                return View(model);
            }
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            SetTitle();
            var _msg = storeDao.Delete(id);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                return RedirectToAction("Index", "Store");
            }
            return RedirectToAction("Index", "Store");
        }
    }
}