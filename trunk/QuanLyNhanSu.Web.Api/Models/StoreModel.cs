using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Api.Models
{
    public class StoreModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string NameGroup { get; set; }
        public int STT { get; set; }
        public string Note { get; set; }
        public bool IsUsed { get; set; }
    }
    
}