using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Web.Filters;
using QuanLyNhanSu.Web.Models;

namespace QuanLyNhanSu.Web.Areas.HeThong.Controllers
{
    [AuthActionFilter]
    [Authorize]
    public class GroupController : BaseControler
    {
        // GET: HeThong/Group
        //GroupDao _grDao = new GroupDao();
        QuanLyNhanSu.Web.ServiceDao.GroupDao _grDao = new ServiceDao.GroupDao();
        public ActionResult Index(string KeyWord="")
        {

            SetTitle();
            var _groups = _grDao.GetList(KeyWord);
            return View(_groups);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetTitle();
            return View();
        }
        [HttpPost]
        public ActionResult Create(GroupModel model)
        {
            SetTitle();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.CreateBy = User.Identity.Name;
            model.UpdateBy = User.Identity.Name;
            model.Active = model.Active;
            var msg = _grDao.Insert(model);
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
            SetTitle();
            return View(_grDao.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(GroupModel model)
        {
            SetTitle();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.UpdateBy = User.Identity.Name;
            var _msg = _grDao.Update(model);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                ViewBag.SuccessMessage = _msg._strDescription;
                return View(model);
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            SetTitle();
            var _msg = _grDao.Delete(id);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                return RedirectToAction("Index", "Group");
            }
            return RedirectToAction("Index", "Group");
        }
        public ActionResult Details(int id)
        {
            Models.GroupDetailModel model = new Models.GroupDetailModel();
           
            model.GroupID = id;
            model.ListFunction= _grDao.GetDetail(id).ToList();
            model.GroupID = id;
            return View(model);
        }
       

        [HttpPost]
        public ActionResult UpdatePermission(string GroupID,int Per,bool value)
        {
            var arrID = GroupID.Split('-');
            var msg = _grDao.UpdatePermission(int.Parse(arrID[0]), int.Parse(arrID[1]), Per, value);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdatePermissionAll(string GroupID, int Per, bool value)
        {
            var arrID = GroupID.Split('-');
            var msg = _grDao.UpdatePermissionAll(int.Parse(arrID[0]), Per, value);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}