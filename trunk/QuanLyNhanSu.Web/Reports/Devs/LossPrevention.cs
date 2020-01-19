using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyNhanSu.Web.Reports.Devs
{
    public partial class LossPrevention : DevExpress.XtraReports.UI.XtraReport
    {
        Models.LossPreventionReport source;
        public LossPrevention(String StoriesID, string FromDateToDate, String Title, Models.LossPreventionReport source)
        {
            InitializeComponent();
            this.source = source;
            this.xrTitle.Text = Title.ToUpper();
            this.xrStorename.Text = WebCommons.DisplayCommons.StoreName(StoriesID);
            this.xrFromDateToDate.Text = FromDateToDate;
            var listLogo = WebCommons.DisplayCommons.ListLogo(StoriesID);
            if (listLogo != null)
            {
                var beginX = 0F;
                var beginY = 10F;
                var Size = new System.Drawing.SizeF(29F, 29F);
                var numcount = 1;
                foreach (var item in listLogo)
                {
                    var picBox = new XRPictureBox();
                    picBox.LocationFloat = new DevExpress.Utils.PointFloat(beginX, beginY);
                    picBox.Name = numcount.ToString();
                    picBox.SizeF = Size;
                    picBox.ImageUrl = item.Path;
                    picBox.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
                    picBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                    this.Bands[BandKind.PageHeader].Controls.Add(picBox);
                    beginX += Size.Width + 2;
                }
            }
            objectDataSource1.DataSource = source.listHeader;
            objectDataSource2.DataSource = source.listDetail;
        }

        private void LossPrevention_AfterPrint(object sender, EventArgs e)
        {
            #region Page 2
            QuanLyNhanSu.Web.Reports.Devs.LossPreventionDetail r2 = new Reports.Devs.LossPreventionDetail(source);

            #endregion
            r2.ShowPrintMarginsWarning = false;
            r2.Margins = new System.Drawing.Printing.Margins(20, 15, 65, 35);
            r2.CreateDocument();
            //gộp 2 Page thành 1
            this.Pages.AddRange(r2.Pages);
        }
    }
}
