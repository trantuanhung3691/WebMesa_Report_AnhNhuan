using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    public class NhanVienModel
    {
       
        public string MANV { get; set; }
        [Required(ErrorMessage ="Name is not empty")]
        public string HOTEN { get; set; }

        public string EMAIL { get; set; }

        public string DIENTHOAI { get; set; }
    }
}