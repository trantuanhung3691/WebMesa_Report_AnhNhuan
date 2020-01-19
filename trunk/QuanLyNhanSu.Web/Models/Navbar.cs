using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    public class Navbar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controler { get; set; }
        public string Action { get; set; }
        public string Class { get; set; }
        public int Order { get; set; }
        public String Icon { get; set; }
    }
}