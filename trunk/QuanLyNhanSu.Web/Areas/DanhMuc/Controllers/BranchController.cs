using QuanLyNhanSu.Web.Filters;
using QuanLyNhanSu.Web.Models;
using System.IO;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.Areas.DanhMuc.Controllers
{
    [AuthActionFilter]
    [Authorize]
    public class BranchController : BaseControler
    {
        // GET: DanhMuc/Branch
        QuanLyNhanSu.Web.ServiceDao.BranchDao branchDao = new ServiceDao.BranchDao();
        public ActionResult Index(string KeyWord = "")
        {
            var _groups = branchDao.GetList(KeyWord);
            return View(_groups);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //SetTitle();
            return View();
        }
        [HttpPost]
        public ActionResult Create(BranchModel model)
        {
            SetTitle();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (Request.Files.Count == 0)
            {
                ViewBag.ErrorMessage = "Please select file to upload!";
                return View(model);
            }
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].ContentLength == 0)
                {
                    ViewBag.ErrorMessage = "Please select file to upload!";
                    return View(model);
                }
                string pathToSave = Server.MapPath("~/Imgs/Logos/Branch/");
                
                var Arrextension = Request.Files[upload].FileName.Split('.');
                var Extension = Arrextension[Arrextension.Length - 1];
                var fileToUpload = string.Format("~/Imgs/Logos/Branch/{0}.{1}", model.BRANCHCODE, Extension);
                var fileName = Path.Combine(fileToUpload);
                Request.Files[upload].SaveAs(Server.MapPath(fileName));
                model.BRANCHLOGO = fileToUpload.Replace("~", "");
            }
            var msg = branchDao.Insert(model);
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
            return View(branchDao.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(BranchModel model)
        {
            SetTitle();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].ContentLength == 0)
                {
                    continue;
                }
                string pathToSave = Server.MapPath("~/Imgs/Logos/Branch/");
                var Arrextension = Request.Files[upload].FileName.Split('.');
                var Extension = Arrextension[Arrextension.Length - 1];
                var fileToUpload = string.Format("~/Imgs/Logos/Branch/{0}.{1}", model.BRANCHCODE, Extension);
                var fileName = Path.Combine(fileToUpload);
                Request.Files[upload].SaveAs(Server.MapPath(fileName));
                model.BRANCHLOGO = fileToUpload.Replace("~", "");
            }
            var _msg = branchDao.Update(model);
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
            var _msg = branchDao.Delete(id);
            if (_msg._msgType == Commons.MessageType.Success)
            {
                return RedirectToAction("Index", "Branch");
            }
            return RedirectToAction("Index", "Branch");
        }
    }
}