using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    
    public class StoreModel
    {
        [Required(ErrorMessage ="Store ID not empty")]
        public string ID { get; set; }
        [Required(ErrorMessage = "Store name not empty")]
        public string Name { get; set; }
        public string NameGroup { get; set; }
        [Required(ErrorMessage = "Store order not empty")]
        public int STT { get; set; }
        public string Note { get; set; }
        public bool IsUsed { get; set; }
        public StoreModel()
        {
            IsUsed = false;
        }
    }
    public class BranchModel
    {
        public string BRANCHCODE { get; set; }

        public string BRANCHNAME { get; set; }
        public string BRANCHCOLOR { get; set; }

        public string BRANCHLOGO { get; set; }
    }
    public class BranchUserModel
    {
        public string BRANCHCODE { get; set; }

        public string BRANCHNAME { get; set; }
        public string BRANCHLOGO { get; set; }
        public bool ISUSE { get; set; }
    }
   
}