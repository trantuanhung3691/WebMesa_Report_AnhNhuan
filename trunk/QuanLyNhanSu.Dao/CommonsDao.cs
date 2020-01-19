using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Dao
{
    public class CommonsDao:BaseDao
    {
        public List<VA_W_CONGTY> GetListCongTy()
        {
            return _db.VA_W_CONGTies.OrderBy(p => p.TENCTY).ToList();
        }
    }
}
