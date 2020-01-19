using QuanLyNhanSu.Dao;
using QuanLyNhanSu.Web.Filters;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.Areas.DanhMuc.Controllers
{
    [Authorize]
    [AuthActionFilter]
    public class ChucVuController : Controller
    {
        // GET: DanhMuc/CHUCVU
        private readonly VA_W_CHUCVUDao _cvDao = new VA_W_CHUCVUDao();
        public ActionResult Index(string KeyWord="")
        {
            var listCHUCVU = _cvDao.GetList(KeyWord);
            return View(listCHUCVU);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(VA_W_CHUCVU model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var msg = _cvDao.Insert(model);
            if (msg._msgType == Commons.MessageType.Success)
            {
                ViewBag.SuccessMessage = msg._strDescription;
                return RedirectToAction("Index","ChucVu");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var CHUCVU = _cvDao.Get(id);
            return View(CHUCVU);
        }
        [HttpPost]
        public ActionResult Edit(VA_W_CHUCVU model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var congtys = new VA_W_CONGTYDao().GetList("");
            
            var _msg = _cvDao.Update(model);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                return RedirectToAction("Index", "ChucVu");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var _msg = _cvDao.Delete(_cvDao.Get(id));
            if (_msg._msgType == Commons.MessageType.Success)
            {
                return RedirectToAction("Index", "ChucVu");
            }
            return RedirectToAction("Index", "ChucVu");
        }
    }
}