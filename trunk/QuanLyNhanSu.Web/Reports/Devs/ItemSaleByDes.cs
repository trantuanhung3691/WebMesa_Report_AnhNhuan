using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanSu.Web.Reports.Devs
{
    public partial class ItemSaleByDes : DevExpress.XtraReports.UI.XtraReport
    {
        public ItemSaleByDes(String StoriesID, string FromDateToDate, String Title, List<Models.ItemSaleByDesReport> source)
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
            var listGroup = source.GroupBy(item => item.ItemCode).Select(p => new Models.ItemSaleByDesReport
            {
                ItemCode = p.First().ItemCode,
                ItemDesc=p.First().ItemDesc,
                Cost = p.Sum(cl => cl.Cost),
                TotAmt = p.Sum(cl => cl.TotAmt),
                Quantity = p.Sum(cl => cl.Quantity),
                sumQuantity=p.First().sumQuantity,
                sumTotAmt=p.First().sumTotAmt
            }).Where(p=>p.ItemCode!="").ToList();
            DetailReport.DataSource = listGroup;
            DetailReport1.DataSource = null;
            DetailReport1.DataSource = source;
        }

    }
}
