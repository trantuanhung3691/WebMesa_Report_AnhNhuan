using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Commons
{
    public class StringCommons
    {
        public static string Prefix = "DWC";
        public static string ImgProfileDefault = @"/Imgs/default_profile.png";
        public static string PwDefault = "987654";
        public static String AppTitle = "VAT REPORT VIEWER";
        public static string ParametterDot = "wrcuencyelwocnh";
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public static string MakeMaNhanVienFriendly(string hoten)
        {
            var tiengvietkhongdau = convertToUnSign3(hoten).ToUpper();
            var arr = tiengvietkhongdau.Split(' ');
            var last = arr[arr.Length - 1];
            var hauto = "";
            for(int i = 0; i <= arr.Length - 2; i++)
            {
                hauto += arr[i].Substring(0, 1);
            }
            return last + hauto;
        }

    }
    public enum PermissionCode
    {
        View=1,
        Create=2,
        Delete=3,
        Edit=4
    }
    public class ControlText
    {
        public static string AddNew="Add new";
        public static string Edit = "Edit";
        public static string Empty = " ";
        public static string View = "View";
        public static string Save = "Save";
        public static string Delete = "Delete";
        public static string GoBack = "Go back";
        public static string Cancel = "Cancel";
        public static string Detail = "Detail";
        public static string Search = "Search";
        public static string Changepass = "Change password";
        public static string PlaceHolderSearch = "Keyword...";
        public static string KeyWordID = "KeyWord";
        public static string Report = "Report";
        public static string Logout = "Log out";
        public static string Myinfo = "My profile";
    }
    public class SessionKeys
    {
        public static string Store = "Stores";
        public static string UserLogin = "UserLogin";
        public static string NgonNgu = "NgonNgu";
        public static string BranchList = "BranchList";
        public static string StoreList = "StoreList";
    }
    public class ReportText
    {
        public static string FromDateToDate = "From {0} to {1}";
    }
    public class DateFormat
    {
        public static string VN = "MM/dd/yyyy";
        public static string US = "dd/MM/yyyy";
    }
    public class FolderUpload
    {
        public static string CongTacs = "/Uploads/CongTacs";
        public static string Users = "/Uploads/Users";
        public static string CONGVANDEN = "/Uploads/CongVanDens";
    }
    public class DenieText
    {
        public static string DenieOnFile = "DenieOnFile";
        public static string DenieOnFolder = "DenieOnFolder";
        public static string DenieDefault = "DenieDefault";
    }
    public class STATUS
    {
        public static string BEGIN = "BEGIN";
        public static string DANG = "DANG";
        public static string SUCCESS = "SUCCESS";
        public static string WAIT = "WAIT";
        public static string WARN = "WARN";
        public static string WORK = "WORK";
    } 
    public class CONFIGVALUE
    {
        public static string SharedFolder=System.Configuration.ConfigurationSettings.AppSettings["ShareFolder"].ToString();
        public static string IconFolderOpen = "glyphicon glyphicon-folder-open";
        public static string IconFolderClose= "glyphicon glyphicon-folder-close";
        public static string IconFile = "glyphicon glyphicon-file";
        public static int NgonNgu = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["NgonNgu"].ToString());
    }
}
