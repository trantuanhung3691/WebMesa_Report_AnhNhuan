using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    public class UserAdminModel
    {

        public string MANV { get; set; }

        public string HOTEN { get; set; }

        public string GIOITINH { get; set; }

        public string EMAIL { get; set; }

        public string CMND { get; set; }

        public string DIENTHOAI { get; set; }

        public string Username { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public string HINHDAIDIEN { get; set; }

        public int Id { get; set; }
        public string Password { get; set; }
    }
}