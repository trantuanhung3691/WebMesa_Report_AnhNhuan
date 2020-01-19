using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;
namespace QuanLyNhanSu.Dao
{
    public class MenuDao:BaseDao
    {
        public IEnumerable<VA_W_GetFunctionListResult> GetMenuBar(string username,int parent = 0)
        {
            return _db.VA_W_GetFunctionList(parent, username);
        }
    }
}
