using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    public class ChartJsModel
    {
        public List<string> labels { get; set; }
        public List<string> codes { get; set; }
        public List<CharJsColumn> data { get; set; }
        public List<HightChartColumn> datahight { get; set; }
        public List<HightChartPie> dataPie { get; set; }
        public string title { get; set; }
        public string titley { get; set; }
        public string titlex { get; set; }
        public string Subtitle { get; set; }
    }
    public class CharJsColumn
    {
        public string label { get; set; }
        public List<double> data { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string yAxisID { get; set; }
    }
    public class HightChartColumn
    {
        public string name { get; set; }
        public List<double> data { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }
    public class HightChartPie
    {
        public string name { get; set; }
        public double y { get; set; }
    }

}