using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyNhanSu.Web.ReportViewers
{
    public partial class ReportViewer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ShowWaiting()
        {
            
        }
        public void CloseWaiting()
        {
        }
        public void CreatePDFFile(Microsoft.Reporting.WebForms.ReportViewer rpViewer, string ReportName)
        {
            var fileFile = string.Format("{0}{1}", ReportName, DateTime.Now.ToString("yyyy_MM_dd_hh_ss"));
            string FileName = "CaoNhanDescription_" + fileFile + ".pdf";
            string extension;
            string encoding;
            string mimeType;
            string[] streams;
            Warning[] warnings;
            Byte[] mybytes = rpViewer.LocalReport.Render("PDF", null,
                          out extension, out encoding,
                          out mimeType, out streams, out warnings);
            using (FileStream fs = File.Create(Server.MapPath("~/Reports/RdlcTemps/" + FileName)))
            {
                fs.Write(mybytes, 0, mybytes.Length);
            }
            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"100%\" height=\"1000px\">";
            //embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
            //embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";
            Session["Embed"] = string.Format(embed, VirtualPathUtility.ToAbsolute("~/Reports/RdlcTemps/" + FileName));
            ltData.Text = Server.HtmlDecode(string.Format(embed, VirtualPathUtility.ToAbsolute("~/Reports/RdlcTemps/" + FileName)));
            // delete all old file
            var folder = new System.IO.DirectoryInfo(Server.MapPath("~/Reports/RdlcTemps/"));
            if (folder != null)
            {
                var files = folder.GetFiles();
                foreach(var file in files)
                {
                    var hasDelete = file.CreationTime.Date < DateTime.Now.Date;
                    if (hasDelete)
                    {
                        file.Delete();
                    }
                }
            }
        }
    }
}