using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Commons;


namespace QuanLyNhanSu.Dao
{
    public class NhanvienDao:BaseDao
    {
        public VA_W_NHANVIEN Get(string MANV)
        {
            return _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(MANV)).SingleOrDefault();
        }
        public List<VA_W_NHANVIEN> GetVA_W_NHANVIENCungCongTy(string manv)
        {
            var nv = _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(manv)).SingleOrDefault();
            if (nv.MACTY.HasValue)
                return _db.VA_W_NHANVIENs.Where(p => p.MACTY.Equals(nv.MACTY)).ToList();
            return _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(manv)).ToList();
        }
        public List<VA_W_NHANVIEN> GetListToCreateUser()
        {
            var listDaCo = _db.VA_W_UserAdmins.Select(p => p.MANV).Distinct();
            return _db.VA_W_NHANVIENs.Where(p => !listDaCo.Contains(p.MANV)).ToList();
        }
        public IEnumerable<VA_W_NHANVIEN> GetList(string keyword)
        {
            if (keyword == null) keyword = "";
            return _db.VA_W_NHANVIENs.Where(p => (p.HOTEN.Contains(keyword)||
            p.DIENTHOAI.Contains(keyword)||
            p.CMND.Contains(keyword)||
            p.DIACHI.Contains(keyword)||
            p.EMAIL.Contains(keyword)));
        }
        
        
        public Message Insert(QuanLyNhanSu.Models.VA_W_NHANVIEN model,String Branchs,String Stores)
        {
            try
            {
                var exist = Get(model.MANV);
                if(exist!=null)
                    return new Message("Employee is exists!", MessageType.Error, "employee is exists");
                //var manv = CreateMANV(model.HOTEN);
                //model.MANV = manv;
                model.HINHDAIDIEN = Commons.StringCommons.ImgProfileDefault;
                _db.VA_W_NHANVIENs.InsertOnSubmit(model);
                _db.SubmitChanges();
                if (!string.IsNullOrEmpty(Branchs))
                {
                    var arrBranchs = Branchs.Split('_');
                    foreach (var item in arrBranchs)
                    {
                        if (item == "") continue;
                        var newItem = new VA_W_USER_BRANCH
                        {
                            BRANCHCODE = item.ToString(),
                            UserName = model.MANV
                        };
                        _db.VA_W_USER_BRANCHes.InsertOnSubmit(newItem);
                        _db.SubmitChanges();
                    }
                }
                if (!string.IsNullOrEmpty(Stores))
                {
                    var arrStores = Stores.Split('_');
                    foreach (var item in arrStores)
                    {
                        if (item == "") continue;
                        var newItem = new VA_W_USER_STORE
                        {
                            StoreID = item.ToString(),
                            UserName = model.MANV
                        };
                        _db.VA_W_USER_STOREs.InsertOnSubmit(newItem);
                        _db.SubmitChanges();
                    }
                }
                
                return new Message(model.HOTEN, MessageType.Success, "Insert employees successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Update(QuanLyNhanSu.Models.VA_W_NHANVIEN vnNhanVien)
        {
            try
            {
                var update = _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(vnNhanVien.MANV)).SingleOrDefault();
                if (update != null)
                {
                    update.HOTEN = vnNhanVien.HOTEN;
                    update.GIOITINH = vnNhanVien.GIOITINH;
                    update.MST = vnNhanVien.MST;
                    update.EMAIL = vnNhanVien.EMAIL;
                    update.QUEQUAN = vnNhanVien.QUEQUAN;
                    update.DIACHI = vnNhanVien.DIACHI;
                    update.CMND = vnNhanVien.CMND;
                    update.NOICAPCMND = vnNhanVien.NOICAPCMND;
                    update.MACTY = vnNhanVien.MACTY;
                    update.TONGIAO = vnNhanVien.TONGIAO;
                    update.QUOCTICH = vnNhanVien.QUOCTICH;
                    update.TINHTRANGHN = vnNhanVien.TINHTRANGHN;
                    update.SOBAOHIEM = vnNhanVien.SOBAOHIEM;
                    update.SOTAIKHOAN = vnNhanVien.SOTAIKHOAN;
                    update.NGANHANG = vnNhanVien.NGANHANG;
                    update.DIENTHOAI = vnNhanVien.DIENTHOAI;
                    update.HINHDAIDIEN = vnNhanVien.HINHDAIDIEN;
                    update.MACTY = vnNhanVien.MACTY;
                }
                _db.SubmitChanges();
                return new Message(vnNhanVien.HOTEN, MessageType.Success, "Update employees successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message UpdateThongTinChung(QuanLyNhanSu.Models.VA_W_NHANVIEN _VA_W_NHANVIEN)
        {
            try
            {
                var update = _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(_VA_W_NHANVIEN.MANV)).SingleOrDefault();
                if (update != null)
                {
                    update.HOTEN = _VA_W_NHANVIEN.HOTEN;
                    update.GIOITINH = _VA_W_NHANVIEN.GIOITINH;
                    update.EMAIL = _VA_W_NHANVIEN.EMAIL;
                    
                    update.DIENTHOAI = _VA_W_NHANVIEN.DIENTHOAI;
                }
                _db.SubmitChanges();
                return new Message(_VA_W_NHANVIEN.HOTEN, MessageType.Success, "Update employees successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message UpdateProfile(QuanLyNhanSu.Models.VA_W_NHANVIEN _VA_W_NHANVIEN)
        {
            try
            {
                var update = _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(_VA_W_NHANVIEN.MANV)).SingleOrDefault();
                if (update != null)
                {
                    update.MST = _VA_W_NHANVIEN.MST;
                    update.SOBAOHIEM = _VA_W_NHANVIEN.SOBAOHIEM;
                    update.SOTAIKHOAN = _VA_W_NHANVIEN.SOTAIKHOAN;
                    update.NGANHANG = _VA_W_NHANVIEN.NGANHANG;
                    update.QUEQUAN = _VA_W_NHANVIEN.QUEQUAN;
                    update.DIACHI = _VA_W_NHANVIEN.DIACHI;
                    update.CMND = _VA_W_NHANVIEN.CMND;
                    update.NOICAPCMND = _VA_W_NHANVIEN.NOICAPCMND;
                    update.TONGIAO = _VA_W_NHANVIEN.TONGIAO;
                    update.QUOCTICH = _VA_W_NHANVIEN.QUOCTICH;
                    update.TINHTRANGHN = _VA_W_NHANVIEN.TINHTRANGHN;
                }
                _db.SubmitChanges();
                return new Message(_VA_W_NHANVIEN.HOTEN, MessageType.Success, "Update employees successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Delete(QuanLyNhanSu.Models.VA_W_NHANVIEN _VA_W_NHANVIEN)
        {
            try
            {
                // delete in branch
                // delete in store
                var brands = _db.VA_W_USER_BRANCHes.Where(p => p.UserName.Equals(_VA_W_NHANVIEN.MANV));
                _db.VA_W_USER_BRANCHes.DeleteAllOnSubmit(brands);
                var stores = _db.VA_W_USER_STOREs.Where(p => p.UserName.Equals(_VA_W_NHANVIEN.MANV));
                _db.VA_W_USER_STOREs.DeleteAllOnSubmit(stores);
                var udate = _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(_VA_W_NHANVIEN.MANV)).SingleOrDefault();
                _db.VA_W_NHANVIENs.DeleteOnSubmit(udate);
                _db.SubmitChanges();
                return new Message(_VA_W_NHANVIEN.HOTEN, MessageType.Success, "Delelte employees successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public string CreateMANV(string HoTen)
        {
            var manvien = Commons.StringCommons.MakeMaNhanVienFriendly(HoTen);
            var checkExist = _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(manvien)).Count();
            if (checkExist > 0)
            {
                // dã tồn tại
                manvien = manvien + (checkExist).ToString();
            }
            return manvien;
            //var max = _db.VA_W_NHANVIENs.Count();
            //return string.Format("{0}{1}",StringCommons.Prefix,(max+1).ToString("D7"));
        }
        public Message UpdateBranch(string UserName, string BranchCode, bool value)
        {
            try
            {
                var exist = _db.VA_W_USER_BRANCHes.Where(p => p.UserName.Equals(UserName) && p.BRANCHCODE.Equals(BranchCode)).SingleOrDefault();
                if (value)
                {
                    if (exist==null)
                    {
                        var newItem = new VA_W_USER_BRANCH
                        {
                            BRANCHCODE=BranchCode,
                            UserName=UserName
                        };
                        _db.VA_W_USER_BRANCHes.InsertOnSubmit(newItem);
                        _db.SubmitChanges();
                        var stores = _db.VA_NAMEs.Where(p => p.ID.Length > 2 && p.ID.Substring(0, 2).Equals(BranchCode)).Select(p => p.ID);
                        var deleteAll = _db.VA_W_USER_STOREs.Where(p => stores.Contains(p.StoreID) && p.UserName.Equals(UserName));
                        _db.VA_W_USER_STOREs.DeleteAllOnSubmit(deleteAll);
                        _db.SubmitChanges();
                        foreach (var item in stores)
                        {
                            var newItemStore = new VA_W_USER_STORE
                            {
                                StoreID = item,
                                UserName = UserName
                            };
                            _db.VA_W_USER_STOREs.InsertOnSubmit(newItemStore);
                            _db.SubmitChanges();
                        }
                                                
                    }
                    
                }
                else
                {
                    // delete
                    if (exist != null)
                    {
                        _db.VA_W_USER_BRANCHes.DeleteOnSubmit(exist);
                        _db.SubmitChanges();
                        var stores = _db.VA_NAMEs.Where(p => p.ID.Length > 2 && p.ID.Substring(0, 2).Equals(BranchCode)).Select(p => p.ID);
                        var deleteAll = _db.VA_W_USER_STOREs.Where(p => stores.Contains(p.StoreID) && p.UserName.Equals(UserName));
                        _db.VA_W_USER_STOREs.DeleteAllOnSubmit(deleteAll);
                        _db.SubmitChanges();
                    }
                }
                return new Message(UserName, MessageType.Success, "Update successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message UpdateStore(string UserName, string StoreCode, bool value)
        {
            try
            {
                var exist = _db.VA_W_USER_STOREs.Where(p => p.UserName.Equals(UserName) && p.StoreID.Equals(StoreCode)).SingleOrDefault();
                if (value)
                {
                    // insert into
                    if (exist == null)
                    {
                        var newItem = new VA_W_USER_STORE
                        {
                            StoreID = StoreCode,
                            UserName = UserName
                        };
                        _db.VA_W_USER_STOREs.InsertOnSubmit(newItem);
                        _db.SubmitChanges();
                    }

                }
                else
                {
                    // delete
                    if (exist != null)
                    {
                        _db.VA_W_USER_STOREs.DeleteOnSubmit(exist);
                        _db.SubmitChanges();
                    }
                }
                return new Message(UserName, MessageType.Success, "Update successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
    }
}
