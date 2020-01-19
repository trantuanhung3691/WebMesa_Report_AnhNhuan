using QuanLyNhanSu.Dao;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.Helper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                var data = System.IO.File.ReadLines(file.FileName);
                var pbDao = new PhongBanDao();
                var nvDao = new NhanVienDao();
                var indexPhongBan = 1;
                var mapb = 0;
                foreach(var line in data)
                {
                    var arrData = line.Split('\t');
                    if (arrData.Length >= 3)
                    {
                        var number = arrData[0];
                        var ten = arrData[1];
                        var dt = arrData[2];
                        if (ten.Equals(""))
                        {
                            // đổ phòng ban
                            var phongban = new PHONGBAN
                            {
                                TENPB=number,
                                MACTY=1,
                                THUTU=indexPhongBan,
                                DIENTHOAI="",
                                DIENTHOAINB="",
                            };
                            var msg=pbDao.Insert(phongban);
                            mapb = phongban.MAPB;
                        }
                        else
                        {
                            //đổ nhân viên
                            var nv = new NHANVIEN
                            {
                                MANV = nvDao.CreateMANV(ten),
                                HOTEN = ten,
                                GIOITINH = "Nam",
                                MST = "",
                                EMAIL = "",
                                QUEQUAN = "",
                                DIACHI = "",
                                CMND = "",
                                NOICAPCMND = "",
                                DIENTHOAI = "",
                                MACTY = 1,
                                TONGIAO = "Không",
                                QUOCTICH = "Việt Nam",
                                TINHTRANGHN = "Độc Thân",
                                SOBAOHIEM = "",
                                SOTAIKHOAN = "",
                                NGANHANG = "",
                                HINHDAIDIEN = "/Imgs/default_profile.png",
                                MANVQL = "Admin",
                                MANVQL2 = "Admin",
                                MAPB = mapb
                            };
                            nvDao.Insert(nv);
                        }
                    }
                    
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userDao = new AccountDao();
            var nvDao = new NhanVienDao();
            var ngdung = userDao.GetList("");
            foreach(var item in ngdung)
            {
                var nv = nvDao.Get(item.MANV);
                if (nv != null)
                {
                    item.Username = Commons.StringCommons.MakeMaNhanVienFriendly(item.HOTEN);
                    var nguoidungupdate = userDao.Get(item.MANV);
                    if (nguoidungupdate != null)
                    {
                        nguoidungupdate.Username = item.Username;
                        var msg = userDao.UpdateUserNameFriendly(nguoidungupdate);
                    }
                }
                
            }

        }
    }
}
