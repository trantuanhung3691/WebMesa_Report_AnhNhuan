using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Dao
{
    public class ReportClass
    {
        public DataSet RP_Consolidation(DateTime FromDate, DateTime ToDate,String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_Consolidation]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_Tender(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_Tender]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_WeeklyHourlyReport(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_WeeklyHourlyReport]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_WeeklyHourlySaleReport(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_WeeklyHourlySaleReport]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_LossPreventionReport(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_LossPreventionReport]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_ItemSaleReport(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_ItemSaleReport]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_ItemSaleByDesReport(DateTime FromDate, DateTime ToDate, String StoreID,string Keyword, string Condition)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID),
                db.MakeInParam("@Keyword", SqlDbType.VarChar, 100, Keyword),
                db.MakeInParam("@Condition", SqlDbType.VarChar, 100, Condition)
            };
            var ds = db.RunExecProc("[RP_W_ItemSaleByDesReport]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_ItemSaleByItemReport(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_ItemSaleByItemReport]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_ItemSaleByTenderReport(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("[RP_W_ItemSaleByTenderReport]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_DiscountByCodeReport(DateTime FromDate, DateTime ToDate, String StoreID)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID)
            };
            var ds = db.RunExecProc("RP_W_DiscountByCodeReport", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_ChartBranchs(DateTime FromDate, DateTime ToDate, String Branchs,int Type,string UserName)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@BranchList", SqlDbType.VarChar, 1000, Branchs),
                db.MakeInParam("@Type", SqlDbType.Int, 8, Type),
                db.MakeInParam("@UserName", SqlDbType.VarChar, 10, UserName)
            };
            var ds = db.RunExecProc("[RP_W_ChartBranchs]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_ChartByBranchs(DateTime FromDate, DateTime ToDate, String Branchs, int Type,string UserName)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@BranchID", SqlDbType.VarChar, 1000, Branchs),
                 db.MakeInParam("@Type", SqlDbType.Int, 8, Type),
                 db.MakeInParam("@UserName", SqlDbType.VarChar, 10, UserName)
            };
            var ds = db.RunExecProc("[RP_W_ChartByBranchs]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet RP_W_ChartByStore(DateTime FromDate, DateTime ToDate, String Branchs,String StoreID, int Type)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@FromDate", SqlDbType.DateTime, 8, FromDate),
                db.MakeInParam("@ToDate", SqlDbType.DateTime, 8, ToDate),
                db.MakeInParam("@BranchID", SqlDbType.VarChar, 10, Branchs),
                db.MakeInParam("@StoreID", SqlDbType.VarChar, 1000, StoreID),
                 db.MakeInParam("@Type", SqlDbType.Int, 8, Type)
            };
            var ds = db.RunExecProc("[RP_W_ChartByStore]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet FC_W_GetNameByCode(String NameGroup,String UserName)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@NameGroup", SqlDbType.VarChar, 100, NameGroup),
                db.MakeInParam("@UserName", SqlDbType.VarChar, 10, UserName)
            };
            var ds = db.RunExecProc("[FC_W_GetNameByCode]", prams);
            db.Dispose();
            return ds;
        }
        public DataSet FC_W_GetNameByBranch(String Branch,String UserName)
        {
            var db = new Database();
            SqlParameter[] prams = {
                db.MakeInParam("@Branch", SqlDbType.VarChar, 1000, Branch),
                db.MakeInParam("@UserName", SqlDbType.VarChar, 10, UserName)
            };
            var ds = db.RunExecProc("[FC_W_GetNameByBranch]", prams);
            db.Dispose();
            return ds;
        }
    }
}
