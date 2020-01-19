using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.Areas.DanhMuc.Controllers
{
    public class NavbarController : Controller
    {
        // GET: HeThong/Navbar
        public ActionResult Navbar(string controller, string action)
        {
            var _mnDao = new ServiceDao.MenuDao();
            var _navbar = _mnDao.GetMenuBar(User.Identity.Name, 0);
            return PartialView("_navbar", _navbar);
        }
    }
}