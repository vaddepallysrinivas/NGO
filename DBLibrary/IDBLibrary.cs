using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    interface IDBLibrary
    {
        Object ExecuteQueryNonQuery(string strConnection, string sFunctionName, SqlParameter[] listInParam);
        void ExecuteQueryIData(string strConnection, DataTable dt, DataSet dsResult, string sStoredProcName, SqlParameter[] listInParam, SqlParameter[] listOutParam, int iTimeOut);
         void ExecuteQuery(string strConnection, string StoredProcName, SqlParameter[] listInParam, SqlParameter[] listOutParam, int TimeOut);
         void ExecuteQueryData(string strConnection, DataTable dt, DataSet dsResult, string sStoredProcName, SqlParameter[] listInParam, SqlParameter[] listOutParam, int iTimeOut);
        
   
      }
}
