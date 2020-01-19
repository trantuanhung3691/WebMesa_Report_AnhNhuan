using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    
    public class CanvasChartModel
    {
        public string title { get; set; }
        public string Subtitle { get; set; }
        public string titlex { get; set; }
        public string titley { get; set; }
        public string valueFormatStringx { get; set; }
        public string valueFormatStringy { get; set; }
        public List<CanvasChartData> data { get; set; }
        public CanvasChartModel()
        {
            title = "";
            titlex = "";
            titley = "";
            valueFormatStringy = "#,###.### VNĐ";
        }
    }
    public class click
    {
        public override string ToString()
        {
            return "OnClick";
        }
    }
    public class CanvasChartData
    {
        public bool showInLegend { get; set; }
        public string click { get; set; }
        public string name { get; set; }
        public string yValueFormatString { get; set; }
        public string type { get; set; }
        public string legendText { get; set; }
        public string toolTipContent { get; set; }//: "{y} - #percent %",
        public List<CanvasPoint> dataPoints { get; set; }
        
        public CanvasChartData()
        {
            showInLegend = true;
        }
    }
    public class CanvasPoint
    {
        public Double y { get; set; }
        public string name { get; set; }
        public String label { get; set; }
        public string indexLabel { get; set; }
    }

    /// <summary>
    ///  customize
    /// </summary>
    public class JDataBranch
    {
        public string GroupBy { get; set; }
        public string BRANCHCODE { get; set; }
        public string BRANCHNAME { get; set; }
        public string BRANCHLOGO { get; set; }
        public string BRANCHCOLOR { get; set; }
        public double DATA { get; set; }
    }
    public class JDataByBranch
    {
        public string GroupBy { get; set; }
        public string StoreNo { get; set; }
        public string Name { get; set; }
        public double DATA { get; set; }
    }
}