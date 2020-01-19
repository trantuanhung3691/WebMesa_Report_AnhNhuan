using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Dao
{
    public class BranchDao : BaseDao
    {
        public VA_W_BRANCH Get(string branch)
        {
            return _db.VA_W_BRANCHes.Where(p => p.BRANCHCODE.Equals(branch)).SingleOrDefault();
        }
        public IEnumerable<VA_W_BRANCH> GetList(string keyword)
        {
            keyword = (string.IsNullOrEmpty(keyword)) ? "" : keyword;
            return _db.VA_W_BRANCHes.Where(p => (p.BRANCHNAME.Contains(keyword)));
        }
        public Message Insert(QuanLyNhanSu.Models.VA_W_BRANCH branch)
        {
            try
            {

                _db.VA_W_BRANCHes.InsertOnSubmit(branch);
                _db.SubmitChanges();
                return new Message(branch.BRANCHNAME, MessageType.Success, "Insert brand successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Update(QuanLyNhanSu.Models.VA_W_BRANCH branch)
        {
            try
            {
                var udate = _db.VA_W_BRANCHes.Where(p => p.BRANCHCODE.Equals(branch.BRANCHCODE)).SingleOrDefault();
                if (udate != null)
                {
                    udate.BRANCHNAME = branch.BRANCHNAME;
                    udate.BRANCHLOGO = branch.BRANCHLOGO;
                }
                _db.SubmitChanges();
                return new Message(branch.BRANCHNAME, MessageType.Success, "Update brand successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Delete(QuanLyNhanSu.Models.VA_W_BRANCH branch)
        {
            try
            {
                var udate = _db.VA_W_BRANCHes.Where(p => p.BRANCHCODE.Equals(branch.BRANCHCODE)).SingleOrDefault();
                _db.VA_W_BRANCHes.DeleteOnSubmit(udate);
                _db.SubmitChanges();
                return new Message(branch.BRANCHNAME, MessageType.Success, "Delelte brand successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
    }
}
