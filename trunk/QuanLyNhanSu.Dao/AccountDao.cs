using QuanLyNhanSu.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
namespace QuanLyNhanSu.Dao
{
    public class AccountDao:BaseDao
    {
        public  VA_W_UserAdmin Login(QuanLyNhanSu.Models.VA_W_UserAdmin user)
        {
            var result = _db.VA_W_UserAdmins.Where(p => p.Username.Equals(user.MANV)
              && p.Password.Equals(user.Password) && p.Active).SingleOrDefault();
            return result;
        }
        public VA_W_UserAdmin Get(string manv)
        {
            var result = _db.VA_W_UserAdmins.Where(p => p.MANV.Equals(manv)).SingleOrDefault();
            return result;
        }
        public VA_W_UserAdmin Login(string username,string password)
        {
            var result = _db.VA_W_UserAdmins.Where(p => p.Username.Equals(username)
              && p.Password.Equals(password) && p.Active).SingleOrDefault();
            return result;
        }
        public Message CreateNguoiDung(QuanLyNhanSu.Models.VA_W_UserAdmin _nguoiDung)
        {
            try
            {
                var nv = _db.VA_W_NHANVIENs.Where(p => p.MANV.Equals(_nguoiDung.MANV)).SingleOrDefault();

                var nguoiDung = new VA_W_UserAdmin
                {
                    MANV = _nguoiDung.MANV,
                    Active = true,
                    CreateBy = _nguoiDung.CreateBy,
                    CreateDate = DateTime.Now,
                    Deleted = false,
                    Password = Commons.Securitys.CalculateMD5Hash(Commons.StringCommons.PwDefault),
                    UpdateBy = _nguoiDung.UpdateBy,
                    Username =_nguoiDung.MANV,
                    UpdateDate = DateTime.Now
                };
                var checkExist = _db.VA_W_UserAdmins.Where(p => p.Username.Equals(nguoiDung.Username)).Count();
                if (checkExist > 0)
                {
                    // dã tồn tại
                    nguoiDung.Username = nguoiDung.Username + (checkExist).ToString();
                }
                _db.VA_W_UserAdmins.InsertOnSubmit(nguoiDung);
                _db.SubmitChanges();
                return new Message(nguoiDung.MANV, MessageType.Success, "Insert user successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message UpdateUserNameFriendly(QuanLyNhanSu.Models.VA_W_UserAdmin _nguoiDung)
        {
            try
            {
                var ng = _db.VA_W_UserAdmins.Where(p => p.Id.Equals(_nguoiDung.Id)).SingleOrDefault();
                ng.Username = _nguoiDung.Username;
                _db.SubmitChanges();
                return new Message(_nguoiDung.MANV, MessageType.Success, "Update user successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message ChangePassword(QuanLyNhanSu.Models.VA_W_UserAdmin _nguoiDung)
        {
            try
            {
                var ngUpdate = Get(_nguoiDung.MANV);
                ngUpdate.Password = _nguoiDung.Password;
                ngUpdate.UpdateDate = DateTime.Now;
                _db.SubmitChanges();
                return new Message(_nguoiDung.MANV, MessageType.Success, "Update user successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public bool AccessPermission(string username,string Controler,QuanLyNhanSu.Commons.PermissionCode _perCode)
        {
            var result = from us in _db.VA_W_UserAdmins
                         join gr in _db.VA_W_GroupUsers on us.Id equals gr.UserId
                         join grp in _db.VA_W_GroupPermissions on gr.GroupId equals grp.GroupId
                         join crm in _db.VA_W_CrmFunctions on grp.FunctionId equals crm.Id
                         where us.Username.Equals(username)
                         && crm.Controler.Equals(Controler)
                         select (new { grp.Mash});
            var mash = result.Select(p=>p.Mash).Distinct().ToList();
            return mash.Contains(_perCode.GetHashCode());
        }
        #region user phần mềm
        public IEnumerable<VA_W_viewNguoiDung> GetList(string KeyWord)
        {
            KeyWord = string.IsNullOrEmpty(KeyWord) ? "" : KeyWord;
            return _db.VA_W_viewNguoiDungs.Where(p => p.HOTEN.ToUpper().Contains(KeyWord) ||
            p.DIENTHOAI.Contains(KeyWord) ||
            p.CMND.Contains(KeyWord) ||
            p.EMAIL.Contains(KeyWord));
        }
        public Message ChangeStatusAccount(int AccountID,bool Status)
        {
            try
            {
                var acc = _db.VA_W_UserAdmins.Where(p => p.Id.Equals(AccountID)).SingleOrDefault();
                if (acc != null)
                {
                    acc.Active = Status;
                    _db.SubmitChanges();
                }
                return new Message(acc.VA_W_NHANVIEN.HOTEN, MessageType.Success, "Change status user successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
            
        }
        public Message ChangeStatusOnGroup(int GroupId,int AccountID, bool Status)
        {
            try
            {
                if (Status)
                {
                    // insert into
                    var checkExist = _db.VA_W_GroupUsers.Where(p => p.GroupId.Equals(GroupId)
                      && p.UserId.Equals(AccountID)).SingleOrDefault();
                    if (checkExist == null)
                    {
                        var newPer = new VA_W_GroupUser
                        {
                            GroupId = GroupId,
                            UserId = AccountID
                        };
                        _db.VA_W_GroupUsers.InsertOnSubmit(newPer);
                        _db.SubmitChanges();
                    }
                }
                else
                {
                    // delete on group
                    var checkExist = _db.VA_W_GroupUsers.Where(p => p.GroupId.Equals(GroupId)
                      && p.UserId.Equals(AccountID)).SingleOrDefault();
                    if (checkExist != null)
                    {
                        _db.VA_W_GroupUsers.DeleteOnSubmit(checkExist);
                        _db.SubmitChanges();
                    }
                }
                return new Message(GroupId.ToString(), MessageType.Success, "Change status user successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }

        }
        public Message ResetPassword(int AccountID)
        {
            try
            {
                var acc = _db.VA_W_UserAdmins.Where(p => p.Id.Equals(AccountID)).SingleOrDefault();
                if (acc != null)
                {
                    acc.Password = Commons.Securitys.CalculateMD5Hash(Commons.StringCommons.PwDefault);
                    acc.UpdateDate = DateTime.Now;
                    _db.SubmitChanges();
                }
                return new Message(acc.VA_W_NHANVIEN.HOTEN, MessageType.Success, "Change status user successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }

        }
        public bool HasPermissionOnGroup(int UserId,int groupid)
        {
            return _db.VA_W_GroupUsers.Where(p => p.GroupId.Equals(groupid) &&
            p.UserId.Equals(UserId)).SingleOrDefault() != null;
        }
        #endregion
        
    }
}
