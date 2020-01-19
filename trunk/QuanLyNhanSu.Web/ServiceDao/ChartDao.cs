using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace QuanLyNhanSu.Web.ServiceDao
{
    public class ChartDao
    {
        public Models.CanvasChartModel getBranchChart(DateTime fromdate, DateTime toDate,String Branchs,int type)
        {
            if (String.IsNullOrEmpty(Branchs))
                return new CanvasChartModel();
            //string branchs, string _fromdate, string _todate
            var url = string.Format("Report/getChartBranchsReport?branchs={0}&_fromdate={1}&_todate={2}&type={3}", Branchs, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"),type);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.JDataBranch> resultTamp = js.Deserialize<List<JDataBranch>>(dataJson.ToString());
            var result = new Models.CanvasChartModel();
            result.title = "Revenue";
            switch (type)
            {
                case 1:
                    result.title += " by date";
                    result.titlex = "Day";
                    break;
                case 2:
                    result.title += " by month";
                    result.titlex = "Month";
                    break;
                case 3:
                    result.title += " by year";
                    result.titlex = "Year";
                    break;
                case 4:
                    result.title += " since "+fromdate.ToString("MM/dd/yyyy")+ " to " + toDate.ToString("MM/dd/yyyy");
                    result.titlex = "Brand";
                    break;
            }
            result.titley = "Revenue(VNĐ)";
            result.data = new List<CanvasChartData>();
            double total = 0;
            List<string> dstemp = new List<string>();
            var distinstDate = resultTamp.Select(p => p.GroupBy).Distinct();
            var distinctBranch = resultTamp.Select(p => new BranchModel { BRANCHNAME = p.BRANCHNAME, BRANCHCODE = p.BRANCHCODE, BRANCHCOLOR = p.BRANCHCOLOR }).ToList().Distinct();
            var listBranchDistinct = new List<BranchModel>();
            foreach (var branch in distinctBranch)
            {
                if (!dstemp.Contains(branch.BRANCHCODE))
                {
                    listBranchDistinct.Add(branch);
                    dstemp.Add(branch.BRANCHCODE);
                }
            }
            foreach (var branch in listBranchDistinct)
            {
                var point = new CanvasChartData();
                point.type = "column";
                point.name = branch.BRANCHCODE;
                point.toolTipContent = "";
                point.dataPoints = new List<CanvasPoint>();
                foreach (var date in distinstDate)
                {
                    var canvasPoint = new CanvasPoint();
                    canvasPoint.label = date;
                    canvasPoint.name = branch.BRANCHCODE;
                    
                    var dt = resultTamp.Where(p => p.GroupBy.Equals(date) &&
                      p.BRANCHCODE.Equals(branch.BRANCHCODE)).SingleOrDefault();
                    if (dt != null)
                    {
                        canvasPoint.y = dt.DATA;
                        total += dt.DATA;
                    }
                    else
                    {
                        canvasPoint.y = 0;
                    }
                    point.dataPoints.Add(canvasPoint);
                }
                result.data.Add(point);
            }
            result.Subtitle = "Total: " + string.Format("{0:0,0} VNĐ", total);
            return result;
        }

        public Models.ChartJsModel getBranchChartJs(DateTime fromdate, DateTime toDate, String Branchs, int type)
        {
            if (String.IsNullOrEmpty(Branchs))
                return new ChartJsModel();
            //string branchs, string _fromdate, string _todate
            var url = string.Format("Report/getChartBranchsReport?branchs={0}&_fromdate={1}&_todate={2}&type={3}", Branchs, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), type);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.JDataBranch> resultTamp = js.Deserialize<List<JDataBranch>>(dataJson.ToString());
            var result = new Models.ChartJsModel();
            result.title = "Revenue";
            switch (type)
            {
                case 1:
                    result.title += " by date";
                    result.titlex = "Day";
                    break;
                case 2:
                    result.title += " by month";
                    result.titlex = "Month";
                    break;
                case 3:
                    result.title += " by year";
                    result.titlex = "Year";
                    break;
                case 4:
                    result.title += " since " + fromdate.ToString("MM/dd/yyyy") + " to " + toDate.ToString("MM/dd/yyyy");
                    result.titlex = "Brand";
                    break;
            }
            result.titley = "Revenue(VNĐ)";
            result.data = new List<CharJsColumn>();
            result.datahight = new List<HightChartColumn>();
            result.labels = new List<string>();
            double total = 0;
            List<string> dstemp = new List<string>();
            var distinstDate = resultTamp.Select(p => p.GroupBy).Distinct();
            result.labels.AddRange(distinstDate);
            var distinctBranch = resultTamp.Select(p => new BranchModel { BRANCHNAME = p.BRANCHNAME, BRANCHCODE = p.BRANCHCODE, BRANCHCOLOR = p.BRANCHCOLOR }).ToList().Distinct();
            var listBranchDistinct = new List<BranchModel>();
            foreach (var branch in distinctBranch)
            {
                if (!dstemp.Contains(branch.BRANCHCODE))
                {
                    listBranchDistinct.Add(branch);
                    dstemp.Add(branch.BRANCHCODE);
                }
            }
            var subLine = "";
            foreach (var branch in listBranchDistinct)
            {
                double totalSub = 0;
                var chartColumn = new CharJsColumn();
                chartColumn.label = branch.BRANCHNAME;
                chartColumn.backgroundColor = branch.BRANCHCOLOR;
                chartColumn.borderColor = branch.BRANCHCOLOR;

                var HightChartItem = new HightChartColumn();
                HightChartItem.name = branch.BRANCHNAME;
                HightChartItem.code = branch.BRANCHCODE;
                HightChartItem.data = new List<double>();
                chartColumn.data = new List<double>();
                foreach (var date in distinstDate)
                {
                    var dt = resultTamp.Where(p => p.GroupBy.Equals(date) &&
                      p.BRANCHCODE.Equals(branch.BRANCHCODE)).SingleOrDefault();
                    if (dt != null)
                    {
                        total += dt.DATA;
                        chartColumn.data.Add(dt.DATA);
                        HightChartItem.data.Add(dt.DATA);
                        totalSub += dt.DATA;
                    }
                    else
                    {
                        chartColumn.data.Add(0);
                        totalSub += 0;
                        HightChartItem.data.Add(0);
                    }
                }
                var strSub = string.Format("{0}:{1:0,0}đ", branch.BRANCHNAME, totalSub);
                subLine += (subLine==string.Empty?strSub : " - " +strSub);
                result.data.Add(chartColumn);
                result.datahight.Add(HightChartItem);
            }
            result.Subtitle = "Total: " + string.Format("{0:0,0} VNĐ", total)+"<br />"+subLine;
            return result;
        }
        public Models.CanvasChartModel getBranchByBranchChart(DateTime fromDate,DateTime toDate, String Branchs, int type)
        {
            //string branchs, string _fromdate, string _todate
            var url = string.Format("Report/getChartByBranchsReport?branchs={0}&_fromdate={1}&_todate={2}&type={3}", Branchs,fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), type);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.JDataByBranch> resultTamp = js.Deserialize<List<JDataByBranch>>(dataJson.ToString());
            var result = new Models.CanvasChartModel();
            result.data = new List<CanvasChartData>();
            result.title = "Revenue of brand " + Branchs + " by store";
            switch (type)
            {
                case 1:
                    result.title += (" on "+toDate.ToString("MM/dd/yyyy"));
                    
                    break;
                case 2:
                    result.title += (" at month "+toDate.ToString("MM/yyyy"));
                    break;
                case 3:
                    result.title += (" at Year " + toDate.Year.ToString("D4"));
                    break;
                case 4:
                    result.title += (" since " + fromDate.ToString("MM/dd/yy")+" ~ " + toDate.ToString("MM/dd/yy"));
                    break;
            }
            result.titlex = "Stores";
            result.titley = "Revenue(VNĐ)";
            var point = new CanvasChartData();
            point.type = "column";
            point.showInLegend = false;
            point.toolTipContent = "{y} VNĐ";
            point.dataPoints = new List<CanvasPoint>();
            double total = 0;
            foreach (var branch in resultTamp)
            {
                total += branch.DATA;
                var datapoint = new CanvasPoint
                {
                    label = branch.Name,
                    name= branch.StoreNo,
                    y=branch.DATA
                };
                point.dataPoints.Add(datapoint);
            }
            result.Subtitle = "Total: " + string.Format("{0:0,0}", total);
            result.data.Add(point);
            return result;
        }


        public Models.ChartJsModel getBranchByBranchChartJs(DateTime fromDate, DateTime toDate, String Branchs, int type)
        {
            //string branchs, string _fromdate, string _todate
            var url = string.Format("Report/getChartByBranchsReport?branchs={0}&_fromdate={1}&_todate={2}&type={3}", Branchs, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), type);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.JDataByBranch> resultTamp = js.Deserialize<List<JDataByBranch>>(dataJson.ToString());
            var result = new Models.ChartJsModel();
            result.data = new List<CharJsColumn>();
            result.datahight = new List<HightChartColumn>();
            result.labels = new List<string>();
            result.codes = new List<string>();
            result.title = "Revenue of brand " + Branchs + " by store";
            switch (type)
            {
                case 1:
                    result.title += (" on " + toDate.ToString("MM/dd/yyyy"));

                    break;
                case 2:
                    result.title += (" at month " + toDate.ToString("MM/yyyy"));
                    break;
                case 3:
                    result.title += (" at Year " + toDate.Year.ToString("D4"));
                    break;
                case 4:
                    result.title += (" since " + fromDate.ToString("MM/dd/yy") + " ~ " + toDate.ToString("MM/dd/yy"));
                    break;
            }
            result.titlex = "Stores";
            result.titley = "Revenue(VNĐ)";
            var point = new HightChartColumn();
            point.data = new List<double>();
            point.name = "Revenue by brand";
            point.description = Branchs;
            double total = 0;
            foreach (var branch in resultTamp)
            {

                total += branch.DATA;
                result.labels.Add(branch.Name);
                result.codes.Add(branch.StoreNo);
                point.data.Add(branch.DATA);
            }
            result.Subtitle = "Total: " + string.Format("{0:0,0}", total);
            result.datahight.Add(point);
            return result;
        }
        public Models.CanvasChartModel getBranchByStoreChart(DateTime fromDate, DateTime toDate, String Branchs,string store, int type)
        {
            //string branchs, string _fromdate, string _todate
            var url = string.Format("Report/getChartByStoreReport?branchs={0}&store={1}&_fromdate={2}&_todate={3}&type={4}", Branchs,store,fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), type);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.JDataByBranch> resultTamp = js.Deserialize<List<JDataByBranch>>(dataJson.ToString());
            var result = new Models.CanvasChartModel();
            result.data = new List<CanvasChartData>();
            result.title = "Revenue of branch " + Branchs + " by store "+ store+" ";
            switch (type)
            {
                case 1:
                    result.title += (" on " + toDate.ToString("MM/dd/yyyy"));
                    break;
                case 2:
                    result.title += (" at month " + toDate.ToString("MM/yyyy"));
                    break;
                case 3:
                    result.title += (" at Year " + toDate.Year.ToString("D4"));
                    break;
                case 4:
                    result.title += (" since " + fromDate.ToString("MM/dd/yy") + " ~ " + toDate.ToString("MM/dd/yy"));
                    break;
            }
            result.titlex = "Stores";
            result.titley = "Revenue";
            var point = new CanvasChartData();
            point.type = "pie";
            point.showInLegend = false;
            point.toolTipContent = "{y} - #percent %";
            point.yValueFormatString = "#,###.### VNĐ";
            point.legendText= "{indexLabel}";
            point.dataPoints = new List<CanvasPoint>();
            double total = 0;
            foreach (var branch in resultTamp)
            {
                total += branch.DATA;
                var datapoint = new CanvasPoint
                {
                    indexLabel=branch.GroupBy,
                    y = branch.DATA
                };
                point.dataPoints.Add(datapoint);
            }
            result.Subtitle = "Total: " + string.Format("{0:0,0}", total);
            result.data.Add(point);
            return result;
        }
        public Models.ChartJsModel getBranchByStoreChartJs(DateTime fromDate, DateTime toDate, String Branchs, string store, int type)
        {
            //string branchs, string _fromdate, string _todate
            var url = string.Format("Report/getChartByStoreReport?branchs={0}&store={1}&_fromdate={2}&_todate={3}&type={4}", Branchs, store, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), type);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.JDataByBranch> resultTamp = js.Deserialize<List<JDataByBranch>>(dataJson.ToString());
            var result = new Models.ChartJsModel();
            result.data = new List<CharJsColumn>();
            result.dataPie = new List<HightChartPie>();
            result.labels = new List<string>();
            result.title = "Revenue of brand " + Branchs + " by store " + store + " ";
            switch (type)
            {
                case 1:
                    result.title += (" on " + toDate.ToString("MM/dd/yyyy"));
                    break;
                case 2:
                    result.title += (" at month " + toDate.ToString("MM/yyyy"));
                    break;
                case 3:
                    result.title += (" at Year " + toDate.Year.ToString("D4"));
                    break;
                case 4:
                    result.title += (" since " + fromDate.ToString("MM/dd/yy") + " ~ " + toDate.ToString("MM/dd/yy"));
                    break;
            }
            result.titlex = "Stores";
            result.titley = "Revenue";
            
            double total = 0;
            foreach (var branch in resultTamp)
            {
                total += branch.DATA;
                var datapoint = new HightChartPie
                {
                    name=branch.GroupBy,
                    y = branch.DATA
                };
                result.dataPie.Add(datapoint);
            }
            result.Subtitle = "Total: " + string.Format("{0:0,0}", total);
            return result;
        }
    }
}