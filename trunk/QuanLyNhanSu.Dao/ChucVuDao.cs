using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Commons;


namespace QuanLyNhanSu.Dao
{
    public class VA_W_CHUCVUDao:BaseDao
    {
        public VA_W_CHUCVU Get(int MAVA_W_CHUCVU)
        {
            return _db.VA_W_CHUCVUs.Where(p => p.MACHUCVU.Equals(MAVA_W_CHUCVU)).SingleOrDefault();
        }
        public IEnumerable<VA_W_CHUCVU> GetList(string keyword)
        {
            return _db.VA_W_CHUCVUs.Where(p => (p.TENCHUCVU.Contains(keyword)));
        }
        public Message Insert(QuanLyNhanSu.Models.VA_W_CHUCVU _VA_W_CHUCVU)
        {
            try
            {
                
                _db.VA_W_CHUCVUs.InsertOnSubmit(_VA_W_CHUCVU);
                _db.SubmitChanges();
                return new Message(_VA_W_CHUCVU.TENCHUCVU, MessageType.Success, "Thêm mới chức vụ thành công");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Update(QuanLyNhanSu.Models.VA_W_CHUCVU _VA_W_CHUCVU)
        {
            try
            {
                var udate = _db.VA_W_CHUCVUs.Where(p => p.MACHUCVU.Equals(_VA_W_CHUCVU.MACHUCVU)).SingleOrDefault();
                if (udate != null)
                {
                    udate.TENCHUCVU = _VA_W_CHUCVU.TENCHUCVU;
                }
                _db.SubmitChanges();
                return new Message(_VA_W_CHUCVU.TENCHUCVU, MessageType.Success, "Cập nhật chức vụ thành công");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Delete(QuanLyNhanSu.Models.VA_W_CHUCVU _VA_W_CHUCVU)
        {
            try
            {
                var udate = _db.VA_W_CHUCVUs.Where(p => p.MACHUCVU.Equals(_VA_W_CHUCVU.MACHUCVU)).SingleOrDefault();
                _db.VA_W_CHUCVUs.DeleteOnSubmit(udate);
                _db.SubmitChanges();
                return new Message(_VA_W_CHUCVU.TENCHUCVU, MessageType.Success, "Xóa chức vụ thành công");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
    }
}
