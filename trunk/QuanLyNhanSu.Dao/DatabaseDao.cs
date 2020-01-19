using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;

namespace QuanLyNhanSu.Dao
{
    public class Database: IDisposable
    {
        public static readonly string Connectionstring = System.Configuration.ConfigurationSettings.AppSettings["connection"].ToString();

        private SqlConnection con;
        public int RunProc(string procName)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);

            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        public void RunProc(string procName, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, prams);

            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // make sure connection is open
            Open();

            //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) );
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            // add proc parameters
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }

            // return param
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
        }

        private SqlCommand CreateCommand(string procName)
        {
            Open();

            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        private void Open()
        {
            // open connection
            if (con == null)
            {
                con = new SqlConnection(Connectionstring);
                con.Open();
            }
        }

        public void Close()
        {
            if (con != null)
                con.Close();
        }

        public void Dispose()
        {
            // make sure connection is closed
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }

        public SqlConnection DBConnection()
        {
            this.Open();
            SqlConnection dbcon = new SqlConnection(this.con.ConnectionString);
            this.Close();
            return dbcon;
        }

        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        private SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        public DataSet ExecutQueryString(string strSQL)
        {
            OpenOnServer();
            SqlCommand myCommand = new SqlCommand(strSQL, con);
            SqlDataAdapter adap = new SqlDataAdapter(myCommand);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }

        public DataSet RunExecProc(string procName, params SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            this.Close();
            return ds;
        }

        public DataSet RunExecProc(string procName)
        {
            SqlCommand cmd = CreateCommand(procName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.Close();
            return ds;
        }

        public object RunExecScalarProc(string procName, params SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            cmd.CommandType = CommandType.StoredProcedure;

            return (object)cmd.ExecuteScalar();
        }

        private void OpenOnServer()
        {
            if (con == null)
            {
                con = new SqlConnection(Connectionstring);
                con.Open();
            }
            //// open connection
            //if (con == null)
            //{
            //    con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["KVNConectionString"]);
            //    con.Open();
            //}


        }

        private SqlCommand CreateCommandOnServer(string procName, SqlParameter[] prams)
        {
            // make sure connection is open
            OpenOnServer();

            //command = new SqlCommand( sprocName, new SqlConnection( ConfigManager.DALConnectionString ) );
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            // add proc parameters
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }

            // return param
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return cmd;
        }

        public int RunProcOnServer(string procName)
        {
            SqlCommand cmd = CreateCommandOnServer(procName, null);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;

        }

        public int RunProcOnServer(string procName, SqlParameter[] prams)
        {

            SqlCommand cmd = CreateCommandOnServer(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;

        }

        public void RunProcOnServer(string procName, out SqlDataReader dataReader)
        {

            SqlCommand cmd = CreateCommandOnServer(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


        }

        public void RunProcOnServer(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {

            SqlCommand cmd = CreateCommandOnServer(procName, prams);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


        }

        public DataSet RunProcOnServer(string procName, double temp)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = CreateCommandOnServer(procName, null);
            //SqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        public SqlDataReader RunProcOnServer(string procName, int empty)
        {
            SqlDataReader dataReader;
            SqlCommand cmd = CreateCommandOnServer(procName, null);
            dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return dataReader;
        }
    }
}
