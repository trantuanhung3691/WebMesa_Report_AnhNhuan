using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Dao
{
    public class BaseDao
    {
        public String _connection;
        public QuanLyNhanSu.Models.HRMDataContext _db;
        public BaseDao()
        {
            _connection = System.Configuration.ConfigurationSettings.AppSettings["connection"].ToString();
            _db = new Models.HRMDataContext(_connection);
        }
    }
}
