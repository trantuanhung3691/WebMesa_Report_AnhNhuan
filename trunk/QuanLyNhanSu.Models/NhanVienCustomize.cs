using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Models
{
    public class NhanVienCustomize
    {
        public string manv { get; set; }
        public string hoten { get; set; }
        public string chucvu { get; set; }
        public bool DaPhanQuyen { get; set; }
        public bool DaXem { get; set; }
        public DateTime NgayXem { get; set; }
    }
    
}
