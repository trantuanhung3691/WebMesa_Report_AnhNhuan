using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    public class GroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Deleted { get; set; }

        public bool Active { get; set; }

        public System.DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public System.DateTime UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
    public class GroupFuctionDetail
    {

        public int GrID { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public int Parent { get; set; }

        public bool _view { get; set; }

        public bool _insert { get; set; }

        public bool _delete { get; set; }

        public bool _update { get; set; }

        public bool _selectAll { get; set; }

        public string ItemID { get; set; }
    }
}