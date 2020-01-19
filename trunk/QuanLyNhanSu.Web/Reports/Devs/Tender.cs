﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyNhanSu.Web.Reports.Devs
{
    public partial class Tender : DevExpress.XtraReports.UI.XtraReport
    {
        public Tender(String StoriesID,string FromDateToDate,String Title)
        {
            InitializeComponent();
            this.xrTitle.Text = Title.ToUpper();
            this.xrStorename.Text= WebCommons.DisplayCommons.StoreName(StoriesID);
            this.xrFromDateToDate.Text = FromDateToDate;
            var listLogo = WebCommons.DisplayCommons.ListLogo(StoriesID);
            if (listLogo != null)
            {
                var beginX = 0F;
                var beginY = 10F;
                var Size= new System.Drawing.SizeF(29F, 29F);
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
        }

    }
}