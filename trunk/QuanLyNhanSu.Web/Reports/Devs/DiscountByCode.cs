using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanSu.Web.Reports.Devs
{
    public partial class DiscountByCode : DevExpress.XtraReports.UI.XtraReport
    {
        public DiscountByCode(String StoriesID, string FromDateToDate, String Title,List<Models.DiscountByCodeReport> totalSource, List<Models.DiscountByCodeReport> detailsource,
            List<Models.DiscountByCodeReport> detailsourceDetail)
        {
            InitializeComponent();
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
            var listGroup = totalSource.GroupBy(item => item.DisDate).Select(p => new Models.GroupDiscountByCodeReport
            {
                DisDate = p.First().DisDate,
                OrgAmt = p.Sum(cl => cl.OrgAmt),
                CItem = p.Sum(cl=>cl.CItem),
                DisAmt = p.Sum(cl => cl.DisAmt),
                DiscID = "",
                DiscName = ""
            }).ToList();
            DetailReportGroup.DataSource = listGroup;
            DetailReportDetail.DataSource = null;
            DetailReportDetail.DataSource = totalSource;
            DetailReport.DataSource = null;
            DetailReport.DataSource = detailsource;
            DetailReport1.DataSource = null;
            DetailReport1.DataSource = detailsourceDetail;
        }

    }
}
