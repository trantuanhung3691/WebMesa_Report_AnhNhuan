using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace QuanLyNhanSu.Web.ServiceDao
{
    public class ReportServiceDao
    {
        public List<TenderReport> getListTenderReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getTender?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];

            var result = new List<TenderReport>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new TenderReport
                {
                    PosNo = (int)item["PosNo"],
                    TransNo = (int)item["TransNo"],
                    PosBizDate = (DateTime)item["PosBizDate"],
                    AmountDue = (decimal)item["AmountDue"],
                    TenderAmt = (decimal)item["TenderAmt"],
                    TrxDateTime = (DateTime)item["TrxDateTime"],
                    StoreNo = (string)item["StoreNo"],
                    AuthId = (string)item["AuthId"]
                };
                result.Add(dataItem);
            }
            return result;
        }
        public ConsolidationReport getListConsolidationReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getConsolidationReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var tbGroupbySalecode = JObject.Parse(data)["Table1"];
            var tbGroupbyDiscount = JObject.Parse(data)["Table2"];
            var tbGroupbyPayment = JObject.Parse(data)["Table3"];
            var tbGroupbyMenu = JObject.Parse(data)["Table4"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.ConsolidationHeader> grHeader = js.Deserialize<List<ConsolidationHeader>>(dataJson.ToString());
            List<Models.ConsolidationGroupBySale> grBySaleCode = js.Deserialize<List<ConsolidationGroupBySale>>(tbGroupbySalecode.ToString());
            List<Models.ConsolidationDiscount> grByDiscount = js.Deserialize<List<ConsolidationDiscount>>(tbGroupbyDiscount.ToString());
            List<Models.ConsolidationPayment> grByPayment = js.Deserialize<List<ConsolidationPayment>>(tbGroupbyPayment.ToString());
            List<Models.ConsolidationMenu> grByMenu = js.Deserialize<List<ConsolidationMenu>>(tbGroupbyMenu.ToString());
            var result = new ConsolidationReport();
            result.listDiscount = grByDiscount;
            result.listHeader = grHeader;
            result.listMenu = grByMenu;
            result.listPayment = grByPayment;
            result.listSaleCode = grBySaleCode;
            return result;
        }
        public List<WeeklyHourlySaleReport> getListWeeklyHourlySaleReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/RP_W_WeeklyHourlySaleReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<WeeklyHourlySaleReport>();
            var sumTrx = 0;
            var sumQua = 0;
            decimal sumAmt = 0;
            var count = 0;
            foreach (JToken item in dataJson)
            {
                var dataItem = new WeeklyHourlySaleReport
                {
                    HOUR = (int)item["HOUR"],
                    SaleAmt = (decimal)item["SaleAmt"],
                    Qua = (int)item["Qua"],
                    Trx = (int)item["Trx"]
                };
                sumTrx += dataItem.Trx;
                sumQua += dataItem.Qua;
                sumAmt += dataItem.SaleAmt;
                count += 1;
                result.Add(dataItem);
            }
            // tính phần trăm
            //int last = 0;
            //double perTrx = 0;
            //double perQua = 0;
            //double perAmt = 0;

            foreach (WeeklyHourlySaleReport item in result)
            {
                item.PerTrx = Math.Round(item.Trx * 1.0 / sumTrx * 100, 2);
                item.PerAmt = Math.Round((double)(item.SaleAmt) * 1.0 / (double)sumAmt * 100, 2);
                item.PerQua = Math.Round(item.Qua * 1.0 / sumQua * 100, 2);
            }
            return result;
        }
        public List<WeeklyHourlyReport> getListWeeklyHourlyReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getWeeklyHourly?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<WeeklyHourlyReport>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new WeeklyHourlyReport
                {
                    DATE = (string)item["DATE"],
                    HOUR = (int)item["HOUR"],
                    SaleAmt = (int)item["SaleAmt"],
                    Trx = (int)item["Trx"],
                    Order = (int)item["Order"],
                    Pax = (int)item["Pax"]
                };
                result.Add(dataItem);
            }
            return result;
        }

        public DiscountByCodeReportModel getDiscountByCodeReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getDiscountByCodeReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var dataJsonDetail = JObject.Parse(data)["Table1"];
            var dataJsonDetail2 = JObject.Parse(data)["Table2"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = new DiscountByCodeReportModel();
            result.detailList = new List<DiscountByCodeReport>();
            result.totalList = new List<DiscountByCodeReport>();
            result.totalList = js.Deserialize<List<DiscountByCodeReport>>(dataJson.ToString());
            result.detailList = js.Deserialize<List<DiscountByCodeReport>>(dataJsonDetail.ToString());
            result.detailListDetail = js.Deserialize<List<DiscountByCodeReport>>(dataJsonDetail2.ToString());
            return result;
        }
        //public List<LossPrevention> getListLossPrevention(string StoreID, DateTime fromdate, DateTime toDate)
        //{
        //    var url = string.Format("Report/getLossPreventionReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
        //    var data = new Services.WebApiCaller().GetUrl(url);
        //    var dataJson = JObject.Parse(data)["Table"];
        //    var result = new List<LossPrevention>();
        //    foreach (JToken item in dataJson)
        //    {
        //        var dataItem = new LossPrevention
        //        {
        //            StoreName = (string)item["StoreName"],
        //            Amount = (decimal)item["Amount"],
        //            Qty = (int)item["Qty"],
        //            StoreNo = (string)item["StoreNo"],
        //            Trans = (int)item["Trans"],
        //            TrxType = (string)item["TrxType"]
        //        };
        //        result.Add(dataItem);
        //    }
        //    return result;
        //}
        public LossPreventionReport getListLossPrevention(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getLossPreventionReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var tbDetail = JObject.Parse(data)["Table1"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Models.LossPreventionHeader> grHeader = js.Deserialize<List<LossPreventionHeader>>(dataJson.ToString());
            List<Models.LossPreventionDetail> grDetail = js.Deserialize<List<LossPreventionDetail>>(tbDetail.ToString());
            var result = new LossPreventionReport();
            result.listHeader = grHeader;
            result.listDetail = grDetail;
            return result;
        }
        public List<ItemSaleReport> getItemSaleReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getItemSaleReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<ItemSaleReport>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new ItemSaleReport
                {
                    Cost = (int)item["Cost"],
                    DiscountAmt = (int)item["DiscountAmt"],
                    ItemCode = (string)item["ItemCode"],
                    ItemDesc = (string)item["ItemDesc"],
                    Name = (string)item["Name"],
                    NetAmt = (int)item["NetAmt"],
                    NetSellPrice = (int)item["NetSellPrice"],
                    Quantity = (int)item["Quantity"],
                    StoreNo = (string)item["StoreNo"],
                    SubCatg = (string)item["SubCatg"],
                    TaxAmt = (decimal)item["TaxAmt"],
                    TotAmt = (int)item["TotAmt"],
                    SubCatgDesc = (string)item["SubCatgDesc"],
                    CatgCode = (string)item["CatgCode"],
                    CatgDesc = (string)item["CatgDesc"]
                };
                result.Add(dataItem);
            }
            return result;
        }
        public List<ItemSaleByDesReport> getItemSaleByDesReport(string StoreID, DateTime fromdate, DateTime toDate, string Keyword, string Condition)
        {
            var url = string.Format("Report/getItemSaleByDesReport?storeid={0}&_fromdate={1}&_todate={2}&_keyword={3}&_condition={4}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"), Keyword, Condition);
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<ItemSaleByDesReport>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new ItemSaleByDesReport
                {
                    Cost = (int)item["Cost"],
                    DiscountAmt = (int)item["DiscountAmt"],
                    ItemCode = (string)item["ItemCode"],
                    ItemDesc = (string)item["ItemDesc"],
                    Name = (string)item["Name"],
                    NetAmt = (int)item["NetAmt"],
                    NetSellPrice = (int)item["NetSellPrice"],
                    Quantity = (int)item["Quantity"],
                    StoreNo = (string)item["StoreNo"],
                    SubCatg = (string)item["SubCatg"],
                    TaxAmt = (decimal)item["TaxAmt"],
                    TotAmt = (int)item["TotAmt"],
                    sumQuantity = (int)item["sumQuantity"],
                    sumTotAmt = (decimal)item["sumTotAmt"],
                    BillNo = (string)item["BillNo"],
                    POSBizDate = (DateTime)item["POSBizDate"],
                    SaleCode = (string)item["SaleCode"]
                };
                result.Add(dataItem);
            }
            return result;
        }
        public List<ItemSaleByItemReport> getItemSaleByItemReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getItemSaleByItemReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<ItemSaleByItemReport>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new ItemSaleByItemReport
                {
                    PosBizDate = (DateTime)item["PosBizDate"],
                    BillNo = (string)item["BillNo"],
                    CashierNo = (string)item["CashierNo"],
                    ItemDesc = (string)item["ItemDesc"],
                    PartySize = (int)item["PartySize"],
                    PosNo = (int)item["PosNo"],
                    SalesCode = (string)item["SalesCode"],
                    SalesCodeMain = (string)item["SalesCodeMain"],
                    ShiftNo = (int)item["ShiftNo"],
                    StartPayTime = (DateTime)item["StartPayTime"],
                    StoreNo = (string)item["StoreNo"],
                    Tax = (decimal)item["Tax"],
                    TotalAmount = (int)item["TotalAmount"],
                    TotalBeforeTax = (int)item["TotalBeforeTax"],
                    TotalCost = item["TotalCost"],
                    TotalSaving = (int)item["TotalSaving"],
                    TransDisc = (int)item["TransDisc"],
                    TransNo = (int)item["TransNo"],
                    TrxVoidType = (int)item["TrxVoidType"],
                    SeqNo = (string)item["SeqNo"],
                    NetAmt = (decimal)item["NetAmt"],
                    NetSellPrice = (decimal)item["NetSellPrice"],
                    Quantity = (int)item["Quantity"],
                    ItemCode = (string)item["ItemCode"]
                };
                result.Add(dataItem);
            }
            return result;
        }
        public List<ItemSaleByTenderReport> getItemSaleByTenderReport(string StoreID, DateTime fromdate, DateTime toDate)
        {
            var url = string.Format("Report/getItemSaleByTenderReport?storeid={0}&_fromdate={1}&_todate={2}", StoreID, fromdate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));
            var data = new Services.WebApiCaller().GetUrl(url);
            var dataJson = JObject.Parse(data)["Table"];
            var result = new List<ItemSaleByTenderReport>();
            foreach (JToken item in dataJson)
            {
                var dataItem = new ItemSaleByTenderReport
                {
                    PosBizDate = (DateTime)item["PosBizDate"],
                    StoreNo = (string)item["StoreNo"],
                    PosNo = (int)item["PosNo"],
                    BillNo = (string)item["BillNo"],
                    Tax = (double)item["Tax"],
                    TotalBeforeTax = (double)item["TotalBeforeTax"],
                    TransDisc = (int)item["TransDisc"],
                    TotalAmount = (int)item["TotalAmount"],
                    TenderDesc = (string)item["TenderDesc"],
                    TenderAmt = (int)item["TenderAmt"],
                    ChangeAmt = (int)item["ChangeAmt"]
                };
                dataItem.SubTotal = Math.Round(dataItem.TotalBeforeTax, MidpointRounding.AwayFromZero);
                result.Add(dataItem);
            }
            return result;
        }
    }
}