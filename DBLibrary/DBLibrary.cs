using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class DBLibrary :IDBLibrary
    {

        public Object ExecuteQueryNonQuery(string strConnection, string sFunctionName, SqlParameter[] listInParam)
        {

            SqlParameter param; ;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            SqlParameter paramReturnValue = new SqlParameter();
            if (strConnection == "")
                throw new Exception("SQL Error: Connection String must be supplied");

            if (sFunctionName.Substring(0, 3) == "fn_")
                cmd.CommandText = "dbo." + sFunctionName;
            else
                cmd.CommandText = sFunctionName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = new System.Data.SqlClient.SqlConnection(strConnection);

            if (listInParam != null)
            {
                for (int i = 0; i < listInParam.Length; i++)
                {
                    param = listInParam[i];
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                }
            }

            paramReturnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(paramReturnValue);

            da.SelectCommand = cmd;
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                da.SelectCommand.ExecuteNonQuery();

                if (paramReturnValue.Value == DBNull.Value)
                    return null;
                else
                    return paramReturnValue.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("SQL Error: " + cmd.CommandText.ToString() + ex.ToString());
            }
        }

        public void ExecuteQuery(string strConnection, string StoredProcName, SqlParameter[] listInParam, SqlParameter[] listOutParam, int TimeOut)
        {
            SqlConnection SqlConn = new SqlConnection(strConnection);
            SqlConn.Open();
            SqlCommand MySQLCommand = new SqlCommand();
            SqlParameter param;

            if (StoredProcName.Substring(0, 5) == "proc_")
                MySQLCommand.CommandText = "dbo." + StoredProcName;
            else
                MySQLCommand.CommandText = StoredProcName;

            if (SqlConn.State == ConnectionState.Closed && !SqlConn.ConnectionString.Contains("async"))
                SqlConn.ConnectionString = SqlConn.ConnectionString + ";async=true;";

            MySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
            MySQLCommand.Connection = SqlConn;
            MySQLCommand.CommandTimeout = TimeOut;

            if (listInParam != null)
            {
                for (int i = 0; i < listInParam.Length; i++)
                {
                    param = listInParam[i];
                    param.Direction = ParameterDirection.Input;
                    MySQLCommand.Parameters.Add(param);
                }
            }

            if (listOutParam != null)
            {
                for (int i = 0; i < listOutParam.Length; i++)
                {
                    param = listOutParam[i];
                    param.Direction = ParameterDirection.Output;
                    MySQLCommand.Parameters.Add(param);
                }
            }

            MySQLCommand.ExecuteNonQuery();
        }

        public  void ExecuteQueryIData(string strConnection, DataTable dt, DataSet dsResult, string sStoredProcName, SqlParameter[] listInParam, SqlParameter[] listOutParam, int iTimeOut)
        {
            SqlParameter param;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                if (strConnection == "")
                    throw new Exception("SQL Error: Connection String must be supplied");

                if (sStoredProcName.Substring(0, 5) == "proc_")
                    cmd.CommandText = "dbo." + sStoredProcName;
                else
                    cmd.CommandText = sStoredProcName;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = new System.Data.SqlClient.SqlConnection(strConnection);

                if (iTimeOut > 0)
                {
                    cmd.CommandTimeout = iTimeOut;
                }


                if (listInParam != null)
                {
                    for (int i = 0; i < listInParam.Length; i++)
                    {
                        param = listInParam[i];
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                }

                if (listOutParam != null)
                {
                    for (int i = 0; i < listOutParam.Length; i++)
                    {
                        param = listOutParam[i];
                        param.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(param);
                    }
                }

                da.SelectCommand = cmd;

                if (dt != null)
                {
                    da.Fill(dt);
                    dt.CaseSensitive = false;
                }
                else
                {
                    da.Fill(dsResult);
                    dsResult.CaseSensitive = false;
                }


                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("SQL Error: " + cmd.CommandText.ToString() + ex.ToString());
            }

            finally
            {
                if (da != null)
                {
                    da.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }

            }
        }


        public void ExecuteQueryData(string strConnection , DataTable dt, DataSet dsResult, string sStoredProcName, SqlParameter[] listInParam, SqlParameter[] listOutParam, int iTimeOut)
        {

            SqlConnection conn = new SqlConnection(strConnection);
            conn.Open();
            
            SqlParameter param;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                if (conn == null)
                    throw new Exception("SQL Error: Proper connection must be supplied");

                if (sStoredProcName.Substring(0, 5) == "proc_")
                    cmd.CommandText = "dbo." + sStoredProcName;
                else
                    cmd.CommandText = sStoredProcName;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conn;
                if (iTimeOut > 0)
                {
                    cmd.CommandTimeout = iTimeOut;
                }


                if (listInParam != null)
                {
                    for (int i = 0; i < listInParam.Length; i++)
                    {
                        param = listInParam[i];
                        param.Direction = ParameterDirection.Input;
                        cmd.Parameters.Add(param);
                    }
                }

                if (listOutParam != null)
                {
                    for (int i = 0; i < listOutParam.Length; i++)
                    {
                        param = listOutParam[i];
                        param.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(param);
                    }
                }

                da.SelectCommand = cmd;

                if (dt != null)
                {
                    da.Fill(dt);
                    dt.CaseSensitive = false;
                }
                else
                {
                    da.Fill(dsResult);
                    dsResult.CaseSensitive = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SQL Error: " + cmd.CommandText.ToString() + ex.ToString());
            }

            finally
            {
                if (da != null)
                {
                    da.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }

            }
        }

        public void ExecuteQuery(string strConnection,string qury)
        {
            SqlConnection SqlConn = new SqlConnection(strConnection);
            if (ConnectionState.Closed == SqlConn.State)
                SqlConn.Open();
            SqlCommand MySQLCommand = new SqlCommand(qury, SqlConn);          
            MySQLCommand.ExecuteNonQuery();
        }

        public Object  ExecuteSclar(string strConnection, string qury)
        {
            SqlConnection SqlConn = new SqlConnection(strConnection);
            if(ConnectionState.Closed==SqlConn.State)
            SqlConn.Open();
            SqlCommand MySQLCommand = new SqlCommand(qury, SqlConn);
           return  MySQLCommand.ExecuteScalar();
        }

       
    }
}
