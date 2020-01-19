using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Web.Models
{
    public class TenderReport
    {
        public string StoreNo { get; set; }
        public int PosNo { get; set; }
        public int TransNo { get; set; }
        public DateTime PosBizDate { get; set; }
        public int SeqNo { get; set; }
        public int TenderID { get; set; }
        public string TenderDesc { get; set; }
        public decimal AmountDue { get; set; }
        public decimal TenderAmt { get; set; }
        public decimal ChangeAmt { get; set; }
        public int TrxVoidType { get; set; }
        public string AuthId { get; set; }
        public string RefNo { get; set; }
        public DateTime TrxDateTime { get; set; }
    }
    public class ConsolidationReport
    {
        public List<ConsolidationHeader> listHeader { get; set; }
        public List<ConsolidationGroupBySale> listSaleCode { get; set; }
        public List<ConsolidationDiscount> listDiscount { get; set; }
        public List<ConsolidationPayment> listPayment { get; set; }
        public List<ConsolidationMenu> listMenu { get; set; }
        public ConsolidationReport()
        {
            listDiscount = new List<ConsolidationDiscount>();
            listHeader = new List<ConsolidationHeader>();
            listMenu = new List<ConsolidationMenu>();
            listPayment = new List<ConsolidationPayment>();
            listSaleCode = new List<ConsolidationGroupBySale>();
        }
    }
    public class ConsolidationHeader
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public decimal? Merchandise { get; set; }
        public decimal? TransDiscount { get; set; }
        public decimal? BeforeTax { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TotalCollectd { get; set; }
        public decimal? ItemDiscount { get; set; }
        public decimal? TransDiscount_col2 { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? ItemVoid_1 { get; set; }
        public decimal? ItemVoid_2 { get; set; }
        public decimal? TransCancel_1 { get; set; }
        public decimal? TransCancel_2 { get; set; }
        public decimal? Postvoid_1 { get; set; }
        public decimal? Postvoid_2 { get; set; }
        public decimal? TransTotal { get; set; }
        public decimal? TotalPax { get; set; }
        public decimal? QtyTotal { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string TotalTime { get; set; }
        public decimal? SaleBill { get; set; }
        public decimal? SalePax { get; set; }
        public decimal? QtyBill { get; set; }
        public decimal? QtyPax { get; set; }
    }
    public class ConsolidationGroupBySale
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public string SaleCode { get; set; }
        public decimal? TotalSale { get; set; }
        public decimal? PerTTL { get; set; }
        public decimal? Pax { get; set; }
        public decimal? PerTTL2 { get; set; }
        public decimal? Bill { get; set; }
        public decimal? PerTTL3 { get; set; }
        public decimal? AvgBill { get; set; }
        public decimal? AvgPax { get; set; }
    }
    public class ConsolidationDiscount
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public string DiscountName { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountCount { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
    public class ConsolidationPayment
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public string PaymentName { get; set; }
        public string PaymentCode { get; set; }
        public int? PaymentCount { get; set; }
        public decimal? PaymentAmount { get; set; }
    }
    public class ConsolidationMenu
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public int? SaleCount { get; set; }
        public decimal? SaleAmount { get; set; }
    }
    public class WeeklyHourlyReport
    {
        public string DATE { get; set; }
        public int HOUR { get; set; }
        public int Trx { get; set; }
        public int SaleAmt { get; set; }
        public int Order { get; set; }
        public int Pax { get; set; }
    }
    public class DiscountByCodeReportModel
    {
        public List<DiscountByCodeReport> totalList;
        public List<DiscountByCodeReport> detailList;
        public List<DiscountByCodeReport> detailListDetail;
    }
    public class DiscountByCodeReport
    {
        public string DisDate { get; set; }
        public string DiscID { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string TransNo { get; set; }
        public string SubCatg { get; set; }
        public string BillNo { get; set; }
        public decimal TotAmt { get; set; }
        public int Quantity { get; set; }
        public string DiscName { get; set; }
        public int CItem { get; set; }
        public decimal DisAmt { get; set; }
        public decimal OrgAmt { get; set; }
    }
    public class GroupDiscountByCodeReport
    {
        public string DisDate { get; set; }
        public string DiscID { get; set; }
        public string DiscName { get; set; }
        public int CItem { get; set; }
        public decimal DisAmt { get; set; }
        public decimal OrgAmt { get; set; }
    }
    public class WeeklyHourlySaleReport
    {
        public int HOUR { get; set; }
        public double PerTrx { get; set; }
        public int Trx { get; set; }
        public int Qua { get; set; }
        public double PerQua { get; set; }
        public decimal SaleAmt { get; set; }
        public double PerAmt { get; set; }
    }
    public class LossPrevention
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public string TrxType { get; set; }
        public int Trans { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
      
    }
    public class LossPreventionReport
    {
        public List<LossPreventionHeader> listHeader { get; set; }
        public List<LossPreventionDetail> listDetail { get; set; }
        public LossPreventionReport()
        {
            listHeader = new List<LossPreventionHeader>();
            listDetail = new List<LossPreventionDetail>();
        }
    }
    public class LossPreventionHeader
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public string TrxType { get; set; }
        public int Trans { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }

    }
    public class LossPreventionDetail
    {
        public string StoreNo { get; set; }
        public string StoreName { get; set; }
        public string TrxType1 { get; set; }
        public int ShiftNo { get; set; }
        public int PosNo { get; set; }
        public string CashierNo { get; set; }
        public string BillNo { get; set; }
        public int TransNo { get; set; }
        public DateTime PosBizDate { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int Quantity { get; set; }
        public decimal TotAmt { get; set; }
    }
    public class ItemSaleReport
    {
        public string StoreNo { get; set; }
        public string Name { get; set; }
        public string SubCatg { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int Quantity { get; set; }
        public int TotAmt { get; set; }
        public int Cost { get; set; }
        public int NetAmt { get; set; }
        public int NetSellPrice { get; set; }
        public int DiscountAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public string SubCatgDesc { get; set; }
        public string CatgCode { get; set; }
        public string CatgDesc { get; set; }
    }
    public class ItemSaleByDesReport
    {
        public string StoreNo { get; set; }
        public string Name { get; set; }
        public string SubCatg { get; set; }
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public int Quantity { get; set; }
        public int TotAmt { get; set; }
        public int Cost { get; set; }
        public int NetAmt { get; set; }
        public int NetSellPrice { get; set; }
        public int DiscountAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public int sumQuantity { get; set; }
        public decimal sumTotAmt { get; set; }
        public DateTime POSBizDate { get; set; }
        public string BillNo { get; set; }
        public string SaleCode { get; set; }
    }
    public class ItemSaleByItemReport
    {
        public string StoreNo { get; set; }
        public int PosNo { get; set; }
        public string BillNo { get; set; }
        public int TransNo { get; set; }
        public DateTime PosBizDate { get; set; }
        public DateTime StartPayTime { get; set; }
        public string SalesCode { get; set; }
        public string SalesCodeMain { get; set; }
        public decimal TotalBeforeTax { get; set; }
        public decimal Tax { get; set; }
        public int TotalAmount { get; set; }
        public int TotalSaving { get; set; }
        public object TotalCost { get; set; }
        public int PartySize { get; set; }
        public int TrxVoidType { get; set; }
        public int TransDisc { get; set; }
        public string TableID { get; set; }
        public string CashierNo { get; set; }
        public int ShiftNo { get; set; }
        public string ItemDesc { get; set; }
        public string SeqNo { get; set; }
        public decimal NetAmt { get; set; }
        public string ItemCode { get; set; }
        public decimal NetSellPrice { get; set; }
        public int Quantity { get; set; }
    }
    public class ItemSaleByTenderReport
    {
        public double SubTotal { get; set; }
        public string StoreNo { get; set; }
        public int PosNo { get; set; }
        public string BillNo { get; set; }
        public int TransNo { get; set; }
        public DateTime PosBizDate { get; set; }
        public DateTime StartPayTime { get; set; }
        public string SalesCode { get; set; }
        public double TotalBeforeTax { get; set; }
        public double Tax { get; set; }
        public int TotalAmount { get; set; }
        public int TotalSaving { get; set; }
        public object TotalCost { get; set; }
        public int PartySize { get; set; }
        public int TrxVoidType { get; set; }
        public int TransDisc { get; set; }
        public string TableID { get; set; }
        public string CashierNo { get; set; }
        public int ShiftNo { get; set; }
        public string StoreNo1 { get; set; }
        public int PosNo1 { get; set; }
        public int TransNo1 { get; set; }
        public DateTime PosBizDate1 { get; set; }
        public int SeqNo { get; set; }
        public int TenderID { get; set; }
        public string TenderDesc { get; set; }
        public int AmountDue { get; set; }
        public int TenderAmt { get; set; }
        public int ChangeAmt { get; set; }
        public int TrxVoidType1 { get; set; }
        public string AuthId { get; set; }
        public string RefNo { get; set; }
        public DateTime TrxDateTime { get; set; }
    }
    public class WeeklyHourlyByDate
    {
        public string Hour { get; set; }
        public decimal mTrx { get; set; }
        public int mAc { get; set; }
        public decimal mAmount { get; set; }
        public decimal tTrx { get; set; }
        public int tAc { get; set; }
        public decimal tAmount { get; set; }
        public decimal wTrx { get; set; }
        public int wAc { get; set; }
        public decimal wAmount { get; set; }
        public decimal thTrx { get; set; }
        public int thAc { get; set; }
        public decimal thAmount { get; set; }
        public decimal fTrx { get; set; }
        public int fAc { get; set; }
        public decimal fAmount { get; set; }
        public decimal saTrx { get; set; }
        public int saAc { get; set; }
        public decimal saAmount { get; set; }
        public decimal suTrx { get; set; }
        public int suAc { get; set; }
        public decimal suAmount { get; set; }

        public decimal sumTrx { get; set; }
        public decimal sumAc { get; set; }
        public decimal sumAmount { get; set; }
    }
}