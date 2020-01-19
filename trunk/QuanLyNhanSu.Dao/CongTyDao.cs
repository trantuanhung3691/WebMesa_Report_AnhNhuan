using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Commons;


namespace QuanLyNhanSu.Dao
{
    public class VA_W_CONGTYDao : BaseDao
    {
        public VA_W_CONGTY Get(int ID)
        {
            return _db.VA_W_CONGTies.Where(p => p.ID.Equals(ID)).SingleOrDefault();
        }
        public IEnumerable<VA_W_CONGTY> GetList(string keyword)
        {
            return _db.VA_W_CONGTies.Where(p => (p.TENCTY.Contains(keyword)));
        }
        public Message Insert(QuanLyNhanSu.Models.VA_W_CONGTY _VA_W_CONGTY)
        {
            try
            {
                
                _db.VA_W_CONGTies.InsertOnSubmit(_VA_W_CONGTY);
                _db.SubmitChanges();
                return new Message(_VA_W_CONGTY.TENCTY, MessageType.Success, "Insert công ty successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Update(QuanLyNhanSu.Models.VA_W_CONGTY _VA_W_CONGTY)
        {
            try
            {
                var udate = _db.VA_W_CONGTies.Where(p => p.ID.Equals(_VA_W_CONGTY.ID)).SingleOrDefault();
                if (udate != null)
                {
                    udate.TENCTY = _VA_W_CONGTY.TENCTY;
                    udate.SODT = _VA_W_CONGTY.SODT;
                    udate.MST = _VA_W_CONGTY.MST;
                    
                }
                _db.SubmitChanges();
                return new Message(_VA_W_CONGTY.TENCTY, MessageType.Success, "Update công ty successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
        public Message Delete(QuanLyNhanSu.Models.VA_W_CONGTY _VA_W_CONGTY)
        {
            try
            {
                var udate = _db.VA_W_CONGTies.Where(p => p.ID.Equals(_VA_W_CONGTY.ID)).SingleOrDefault();
                _db.VA_W_CONGTies.DeleteOnSubmit(udate);
                _db.SubmitChanges();
                return new Message(_VA_W_CONGTY.TENCTY, MessageType.Success, "Delelte công ty successfull");
            }
            catch (Exception ex)
            {
                return new Message(ex.Message, MessageType.Error, ex.Message);
            }
        }
    }
}
