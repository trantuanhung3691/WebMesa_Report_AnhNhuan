using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Web.WebCommons
{
    public class DropdownCommons
    {
        
        public static SelectList DropDownStories
        {
            get
            {
                ServiceDao.StoreDao _cmDao = new ServiceDao.StoreDao();
                var congtys = _cmDao.getList("STORE");
                
                var result = new SelectList(congtys, "ID", "Name");
                return result;
            }
        }
        public static SelectList DropDownBranchs
        {
            get
            {
                ServiceDao.BranchDao _cmDao = new ServiceDao.BranchDao();
                var congtys = _cmDao.GetList("");
                var result = new SelectList(congtys, "BRANCHCODE", "BRANCHNAME");
                return result;
            }
        }
        public static SelectList DropDownNhanVienMacDinh
        {
            get
            {
                QuanLyNhanSu.Web.ServiceDao.NhanVienDao _nvDao = new QuanLyNhanSu.Web.ServiceDao.NhanVienDao();
                var xeploai = _nvDao.GetList("");
                var result = new SelectList(xeploai, "MANV", "HOTEN");
                return result;
            }
        }
        
        public static SelectList DropDownAddNguoiDungNew
        {
            get
            {
                QuanLyNhanSu.Web.ServiceDao.NhanVienDao _nvDao = new QuanLyNhanSu.Web.ServiceDao.NhanVienDao();
                var xeploai = _nvDao.GetListToCreateUser();
                var result = new SelectList(xeploai, "MANV", "HOTEN");
                return result;
            }
        }
     
    }
}