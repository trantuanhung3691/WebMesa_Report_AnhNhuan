using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Commons;


namespace QuanLyNhanSu.Dao
{
    public class VA_W_PHONGBANDao:BaseDao
    {
        public VA_W_PHONGBAN Get(int MAPB)
        {
            return _db.VA_W_PHONGBANs.Where(p => p.MAPB.Equals(MAPB)).SingleOrDefault();
        }
        public IEnumerable<VA_W_PHONGBAN> GetList(string keyword)
        {
            return _db.VA_W_PHONGBANs.Where(p => (p.TENPB.Contains(keyword)));
        }
        public Message Insert(QuanLyNhanSu.Models.VA_W_PHONGBAN _VA_W_PHONGBAN)
        {
            try
            {
                
                _db.VA_W_PHONGBANs.InsertOnSubmit(_VA_W_PHONGBAN);
                _db.SubmitChanges();
                return new Message(_VA_W_PHONGBAN.TENPB, MessageType.Success, "Thêm mới phòng ban thành công");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Update(QuanLyNhanSu.Models.VA_W_PHONGBAN _VA_W_PHONGBAN)
        {
            try
            {
                var udate = _db.VA_W_PHONGBANs.Where(p => p.MAPB.Equals(_VA_W_PHONGBAN.MAPB)).SingleOrDefault();
                if (udate != null)
                {
                    udate.TENPB = _VA_W_PHONGBAN.TENPB;
                    udate.DIENTHOAI = _VA_W_PHONGBAN.DIENTHOAI;
                    udate.DIENTHOAINB = _VA_W_PHONGBAN.DIENTHOAINB;
                    udate.THUTU = _VA_W_PHONGBAN.THUTU;
                    udate.MACTY = _VA_W_PHONGBAN.MACTY;
                }
                _db.SubmitChanges();
                return new Message(_VA_W_PHONGBAN.TENPB, MessageType.Success, "Cập nhật phòng ban thành công");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Delete(QuanLyNhanSu.Models.VA_W_PHONGBAN _VA_W_PHONGBAN)
        {
            try
            {
                var udate = _db.VA_W_PHONGBANs.Where(p => p.MAPB.Equals(_VA_W_PHONGBAN.MAPB)).SingleOrDefault();
                _db.VA_W_PHONGBANs.DeleteOnSubmit(udate);
                _db.SubmitChanges();
                return new Message(_VA_W_PHONGBAN.TENPB, MessageType.Success, "Xóa phòng ban thành công");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
    }
}
