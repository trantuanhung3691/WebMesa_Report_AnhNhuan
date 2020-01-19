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
    public class PhongBanController : Controller
    {
        // GET: DanhMuc/PhongBan
        private readonly VA_W_PHONGBANDao _pbDao = new VA_W_PHONGBANDao();
        public ActionResult Index(string KeyWord="")
        {
            var listPhongBan = _pbDao.GetList(KeyWord);
            return View(listPhongBan);
        }
        public ActionResult Create()
        {
            var congtys = new VA_W_CONGTYDao().GetList("");
            SelectList list = new SelectList(congtys, "ID", "TENCTY", 1);
            ViewBag.CongTys = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(VA_W_PHONGBAN model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var congtys = new VA_W_CONGTYDao().GetList("");
            SelectList list = new SelectList(congtys, "ID", "TENCTY",  1);
            ViewBag.CongTys = list;
            var msg = _pbDao.Insert(model);
            if (msg._msgType == Commons.MessageType.Success)
            {
                ViewBag.SuccessMessage = msg._strDescription;
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var congtys = new VA_W_CONGTYDao().GetList("");
            var phongban = _pbDao.Get(id);
            SelectList list = new SelectList(congtys, "ID", "TENCTY", phongban.MACTY.HasValue ? phongban.MACTY.Value : 0);
            ViewBag.CongTys = list;
            return View(_pbDao.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(VA_W_PHONGBAN model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var congtys = new VA_W_CONGTYDao().GetList("");
            
            var _msg = _pbDao.Update(model);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                var phongban = _pbDao.Get(model.MAPB);
                SelectList list = new SelectList(congtys, "ID", "TENCTY", phongban.MACTY.HasValue ? phongban.MACTY.Value : 0);
                ViewBag.CongTys = list;
                ViewBag.SuccessMessage = _msg._strDescription;
                return View(model);
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var _msg = _pbDao.Delete(_pbDao.Get(id));
            if (_msg._msgType == Commons.MessageType.Success)
            {
                return RedirectToAction("Index", "PhongBan");
            }
            return RedirectToAction("Index", "PhongBan");
        }
    }
}