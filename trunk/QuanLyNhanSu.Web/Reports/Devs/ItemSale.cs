using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanSu.Web.Reports.Devs
{
    public partial class ItemSale : DevExpress.XtraReports.UI.XtraReport
    {
        public ItemSale(String StoriesID, string FromDateToDate, String Title, List<Models.ItemSaleReport> source)
        {
            InitializeComponent();
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
            var groupbyItemCode = source.GroupBy(item => item.ItemCode).Select(p => new Models.ItemSaleReport
            {
                ItemCode = p.First().ItemCode,
                ItemDesc=p.First().ItemDesc,
                CatgCode = p.First().CatgCode,
                CatgDesc = p.First().CatgDesc,
                Cost = p.Sum(cl => cl.Cost),
                TotAmt = p.Sum(cl => cl.TotAmt),
                Quantity = p.Sum(cl => cl.Quantity),
            }).Where(p=>p.ItemCode!="").ToList();

            var groupbyCat = source.GroupBy(item => item.CatgCode).Select(p => new Models.ItemSaleReport
            {
                CatgCode = p.First().CatgCode,
                CatgDesc = p.First().CatgDesc,
                Cost = p.Sum(cl => cl.Cost),
                TotAmt = p.Sum(cl => cl.TotAmt),
                Quantity = p.Sum(cl => cl.Quantity),
            }).Where(p => p.CatgCode != "").ToList();
            var groupbySubCat = source.GroupBy(item => item.SubCatg).Select(p => new Models.ItemSaleReport
            {
                SubCatg = p.First().SubCatg,
                SubCatgDesc = p.First().SubCatgDesc,
                CatgCode=p.First().CatgCode,
                CatgDesc = p.First().CatgDesc,
                Cost = p.Sum(cl => cl.Cost),
                TotAmt = p.Sum(cl => cl.TotAmt),
                Quantity = p.Sum(cl => cl.Quantity),
            }).Where(p => p.SubCatg != "").ToList();
            DetailItemCode.DataSource = groupbyItemCode;
            DetailCat.DataSource = null;
            DetailCat.DataSource = groupbyCat;
            DetailSubCat.DataSource = null;
            DetailSubCat.DataSource = groupbySubCat;
            DetailReport.DataSource = null;
            DetailReport.DataSource = source;
        }

    }
}
