using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Commons;


namespace QuanLyNhanSu.Dao
{
    public class StoriesDao : BaseDao
    {
        public VA_NAME Get(string MAVA_STORy)
        {
            return _db.VA_NAMEs.Where(p => p.ID.Equals(MAVA_STORy)).SingleOrDefault();
        }
        public IEnumerable<VA_NAME> GetList(string keyword)
        {
            keyword = (string.IsNullOrEmpty(keyword)) ? "" : keyword;
            return _db.VA_NAMEs.Where(p =>p.NameGroup.Equals("STORE")&& (p.Name.Contains(keyword)));
        }
        public Message Insert(QuanLyNhanSu.Models.VA_NAME _VA_STORy)
        {
            try
            {
                _db.VA_NAMEs.InsertOnSubmit(_VA_STORy);
                _db.SubmitChanges();
                var brands = _db.VA_W_USER_BRANCHes.Where(p => p.BRANCHCODE.Equals(_VA_STORy.ID.Substring(0, 2)));
                foreach(var user in brands)
                {
                    var storeuser = new VA_W_USER_STORE
                    {
                        StoreID = _VA_STORy.ID,
                        UserName = user.UserName
                    };
                    var checkExist = _db.VA_W_USER_STOREs.Where(p => p.UserName.Equals(storeuser.UserName)
                      && p.StoreID.Equals(storeuser.StoreID)).SingleOrDefault();
                    if (checkExist == null)
                    {
                        _db.VA_W_USER_STOREs.InsertOnSubmit(storeuser);
                        _db.SubmitChanges();
                    }
                }
                return new Message(_VA_STORy.Name, MessageType.Success, "Insert store successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Update(QuanLyNhanSu.Models.VA_NAME _VA_STORy)
        {
            try
            {
                var udate = _db.VA_NAMEs.Where(p =>p.NameGroup.Equals(_VA_STORy.NameGroup)&& p.ID.Equals(_VA_STORy.ID)).SingleOrDefault();
                if (udate != null)
                {
                    udate.Name = _VA_STORy.Name;
                    udate.Note = _VA_STORy.Note;
                    udate.STT = _VA_STORy.STT;
                    
                }
                _db.SubmitChanges();
                return new Message(_VA_STORy.Name, MessageType.Success, "Update store successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Delete(QuanLyNhanSu.Models.VA_NAME _VA_STORy)
        {
            try
            {
                var udate = _db.VA_NAMEs.Where(p => p.ID.Equals(_VA_STORy.ID)).SingleOrDefault();
                _db.VA_NAMEs.DeleteOnSubmit(udate);
                _db.SubmitChanges();
                return new Message(_VA_STORy.Name, MessageType.Success, "Delelte story successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }

        public List<VA_W_BRANCH> GetBranchs()
        {
            return _db.VA_W_BRANCHes.ToList();
        }
        public List<BranchUserModel> GetBranchUsers(string userID)
        {
            var result = new List<BranchUserModel>();
            var branchs= _db.VA_W_BRANCHes.ToList();
            foreach(var item in branchs)
            {
                var newItem = new BranchUserModel { BRANCHCODE = item.BRANCHCODE, BRANCHLOGO = item.BRANCHLOGO, BRANCHNAME = item.BRANCHNAME };
                var hasIsUse = _db.VA_W_USER_BRANCHes.Where(p => p.UserName.Equals(userID)
                  && p.BRANCHCODE.Equals(item.BRANCHCODE)).Count() > 0;
                newItem.ISUSE = hasIsUse;
                result.Add(newItem);
            }
            return result;
        }
        public List<BranchUserModel> GetBranchManaged(string userName)
        {
            var result = new List<BranchUserModel>();
            var branchs = _db.VA_W_BRANCHes.ToList();
            foreach (var item in branchs)
            {
                var newItem = new BranchUserModel { BRANCHCODE = item.BRANCHCODE, BRANCHLOGO = item.BRANCHLOGO, BRANCHNAME = item.BRANCHNAME };
                var hasIsUse = _db.VA_W_USER_BRANCHes.Where(p => p.UserName.Equals(userName)
                  && p.BRANCHCODE.Equals(item.BRANCHCODE)).Count() > 0;
                newItem.ISUSE = hasIsUse;
                if(hasIsUse)
                    result.Add(newItem);
            }
            return result;
        }
    }
}
