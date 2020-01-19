using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Dao
{
    public class VA_W_NGONNGUDao:BaseDao
    {
        
        public VA_W_NGONNGU Get(string ColumnName)
        {
            return _db.VA_W_NGONNGUs.Where(p => p.ColumnName.Equals(ColumnName)).SingleOrDefault();
        }
        public List<VA_W_NGONNGU> GetList()
        {
            return _db.VA_W_NGONNGUs.ToList();
        }
        public string Get(string ColumnName,int language)
        {
            var VA_W_NGONNGU= _db.VA_W_NGONNGUs.Where(p => p.ColumnName.Equals(ColumnName)).SingleOrDefault();
            switch (language)
            {
                case 1:
                    return VA_W_NGONNGU.TiengViet;
                    break;
                case 2:
                    return VA_W_NGONNGU.TiengAnh;
                    break;
                default:
                    return VA_W_NGONNGU.TiengViet;
            }
        }
    }
}
