using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Dao
{
    public class GroupDao:BaseDao
    {
        public VA_W_Group Get(int id)
        {
            return _db.VA_W_Groups.Where(p => p.Id.Equals(id)).SingleOrDefault();
        }
        public IEnumerable<VA_W_Group> GetList(string keyword)
        {
            keyword = keyword == null ? "" : keyword;
            return _db.VA_W_Groups.Where(p => p.Active && (p.Name.Contains(keyword)));
        }
        public Message Insert(QuanLyNhanSu.Models.VA_W_Group _VA_W_Group)
        {
            try
            {
                _VA_W_Group.Deleted = false;
                _VA_W_Group.CreateDate = DateTime.Now;
                _VA_W_Group.UpdateDate = DateTime.Now;
                _VA_W_Group.Active = true;
                _db.VA_W_Groups.InsertOnSubmit(_VA_W_Group);
                _db.SubmitChanges();
                return new Message(_VA_W_Group.Name, MessageType.Success, "Insert group permission successfull");
            }
            catch(Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Update(QuanLyNhanSu.Models.VA_W_Group model)
        {
            try
            {
                var udate = _db.VA_W_Groups.Where(p => p.Id.Equals(model.Id)).SingleOrDefault();
                if (udate != null)
                {
                    udate.Name = model.Name;
                    udate.Description = model.Description;
                    udate.UpdateDate = DateTime.Now;
                    udate.UpdateBy = model.UpdateBy;
                }
                _db.SubmitChanges();
                return new Message(model.Name, MessageType.Success, "Update group permission successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Delete(QuanLyNhanSu.Models.VA_W_Group _VA_W_Group)
        {
            try
            {
                var udate = _db.VA_W_Groups.Where(p => p.Id.Equals(_VA_W_Group.Id)).SingleOrDefault();
                if (udate != null)
                {
                    udate.Deleted = true;
                    udate.Active = false;
                }
                _db.SubmitChanges();
                return new Message(_VA_W_Group.Name, MessageType.Success, "Delelte group permission successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public IEnumerable<VA_W_hrm_GetFuntionResult> GetDetail(int id)
        {
            return _db.VA_W_hrm_GetFuntion(id);
        }
        
        public Message UpdatePermission(int grID,int FunctionID,int Mash,bool value,string createby)
        {
            var result = new Message();
            try
            {
                if (Mash == 5)
                {
                    var listToDelte = _db.VA_W_GroupPermissions.Where(p => p.GroupId.Equals(grID) &&
                      p.FunctionId.Equals(FunctionID));
                    _db.VA_W_GroupPermissions.DeleteAllOnSubmit(listToDelte);
                    _db.SubmitChanges();
                    if (value)
                    {
                        for (var i = 1; i <= 4; i++)
                        {
                            var insert = new VA_W_GroupPermission
                            {
                                GroupId = grID,
                                FunctionId = FunctionID,
                                Mash = i,
                                CreateBy = createby
                            };
                            _db.VA_W_GroupPermissions.InsertOnSubmit(insert);
                            _db.SubmitChanges();
                        }
                       
                    }
                }
                else
                {
                    var checkExist = _db.VA_W_GroupPermissions.Where(p => p.GroupId.Equals(grID) &&
                                                  p.FunctionId.Equals(FunctionID) && p.Mash.Equals(Mash)
                                                  ).SingleOrDefault();
                    if (value)
                    {
                        if (checkExist != null)
                        {
                            //insert
                            _db.VA_W_GroupPermissions.DeleteOnSubmit(checkExist);
                            _db.SubmitChanges();
                        }
                        else
                        {
                            var insert = new VA_W_GroupPermission
                            {
                                GroupId = grID,
                                FunctionId = FunctionID,
                                Mash = Mash,
                                CreateBy = createby
                            };
                            _db.VA_W_GroupPermissions.InsertOnSubmit(insert);
                            _db.SubmitChanges();
                        }
                    }
                    else
                    {
                        if (checkExist != null)
                        {
                            //insert
                            _db.VA_W_GroupPermissions.DeleteOnSubmit(checkExist);
                            _db.SubmitChanges();
                        }
                    }
                }
                result._msgType = MessageType.Success;
                result._strDescription = "Update successfull";
                result._strMsg = "Update phân quyền successfull";
            }
            catch(Exception ex)
            {
                result._msgType = MessageType.Error;
                result._strDescription = ex.Message;
                result._strMsg = "Update phân quyền không successfull";
            }
            return result;
        }


        public Message UpdatePermissionAll(int grID, int Mash, bool value, string createby)
        {
            var result = new Message();
            try
            {
                if (Mash == 5)
                {
                    var listToDelte = _db.VA_W_GroupPermissions.Where(p => p.GroupId.Equals(grID));
                    _db.VA_W_GroupPermissions.DeleteAllOnSubmit(listToDelte);
                    _db.SubmitChanges();
                    if (value)
                    {
                        //for (var i = 1; i <= 4; i++)
                        //{
                        //    var insert = new VA_W_GroupPermission
                        //    {
                        //        VA_W_GroupId = grID,
                        //        FunctionId = FunctionID,
                        //        Mash = i,
                        //        CreateBy = createby
                        //    };
                        //    _db.VA_W_GroupPermissions.InsertOnSubmit(insert);
                        //    _db.SubmitChanges();
                        //}

                    }
                }
                else
                {
                    var checkExist = _db.VA_W_GroupPermissions.Where(p => p.GroupId.Equals(grID) && p.Mash.Equals(Mash));
                    if (value)
                    {
                        _db.VA_W_GroupPermissions.DeleteAllOnSubmit(checkExist);
                        _db.SubmitChanges();
                        var listFunction = _db.VA_W_CrmFunctions.Where(p => p.Deleted == false);
                        foreach(var item in listFunction)
                        {
                            var insert = new VA_W_GroupPermission
                            {
                                GroupId = grID,
                                FunctionId = item.Id,
                                Mash = Mash,
                                CreateBy = createby
                            };
                            _db.VA_W_GroupPermissions.InsertOnSubmit(insert);
                            _db.SubmitChanges();
                        }
                    }
                    else
                    {
                        _db.VA_W_GroupPermissions.DeleteAllOnSubmit(checkExist);
                        _db.SubmitChanges();
                    }
                }
                result._msgType = MessageType.Success;
                result._strDescription = "Update successfull";
                result._strMsg = "Update phân quyền successfull";
            }
            catch (Exception ex)
            {
                result._msgType = MessageType.Error;
                result._strDescription = ex.Message;
                result._strMsg = "Update phân quyền không successfull";
            }
            return result;
        }
    }
}
