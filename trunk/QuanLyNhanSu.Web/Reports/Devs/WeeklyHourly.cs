using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QuanLyNhanSu.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanSu.Web.Reports.Devs
{
    public partial class WeeklyHourly : DevExpress.XtraReports.UI.XtraReport
    {
        public WeeklyHourly(String StoriesID, string FromDateToDate, String Title, List<WeeklyHourlyReport> source)
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
            var distinctHours = source.OrderBy(p=>p.HOUR).Select(p => p.HOUR).Distinct();
            var distinctDate = source.Select(p => p.DATE).Distinct();
            var result = new List<WeeklyHourlyByDate>();
            foreach(var hour in distinctHours)
            {
                var title = string.Format("{0}:00 ~ {1}:00 {2}", hour, hour + 1, hour < 12 ? "AM" : "PM");
                var item = new WeeklyHourlyByDate();
                item.Hour = title;
                foreach(var date in distinctDate)
                {
                    var total = source.Where(p => p.DATE.Equals(date)
                      && p.HOUR.Equals(hour));
                    var trx = total.Sum(p => p.Trx);
                    var amt = total.Sum(p => p.SaleAmt);
                    //decimal Ac=trx==0?0:( (decimal)Math.Round((amt * 1.0 / trx), 2, MidpointRounding.AwayFromZero)); 
                    int Ac = total.Sum(p => p.Pax);
                    switch (date)
                    {
                        case "Mon":
                            item.mTrx = trx;
                            item.mAmount = amt;
                            item.mAc = Ac;
                            break;
                        case "Tue":
                            item.tTrx = trx;
                            item.tAmount = amt;
                            item.tAc = Ac;
                            break;
                        case "Wed":
                            item.wTrx = trx;
                            item.wAmount = amt;
                            item.wAc = Ac;
                            break;
                        case "Thu":
                            item.thTrx = trx;
                            item.thAmount = amt;
                            item.thAc = Ac;
                            break;
                        case "Fri":
                            item.fTrx = trx;
                            item.fAmount = amt;
                            item.fAc = Ac;
                            break;
                        case "Sat":
                            item.saTrx = trx;
                            item.saAmount = amt;
                            item.saAc = Ac;
                            break;
                        case "Sun":
                            item.suTrx = trx;
                            item.suAmount = amt;
                            item.suAc = Ac;
                            break;
                    }
                    
                }
                item.sumTrx = item.mTrx + item.tTrx + item.wTrx + item.thTrx + item.fTrx + item.saTrx + item.suTrx;
                item.sumAmount = item.mAmount + item.tAmount + item.wAmount + item.thAmount + item.fAmount + item.saAmount + item.suAmount;
                //item.sumAc = (decimal)Math.Round((item.sumAmount / item.sumTrx), 2, MidpointRounding.AwayFromZero);
                item.sumAc = item.mAc + item.tAc + item.wAc + item.thAc + item.fAc + item.saAc + item.suAc;
                result.Add(item);
            }
            this.DataSource = result;
        }

    }
}
