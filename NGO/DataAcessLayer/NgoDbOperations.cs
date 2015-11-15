using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace NGO.DataAcessLayer
{
    public class NgoDbOperations
    {

        DBLibrary.DBLibrary lobj = new DBLibrary.DBLibrary();
        DataTable dt;
        XmlDocument xml;
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ngoConstring"].ToString();

        public List<Notification> GetNotificationsList()
        {
            List<Notification> lst = new List<Notification>();
            //SqlParameter param = new SqlParameter("@err_msg", SqlDbType.VarChar, 500);
            //lobj.ExecuteQueryData(

            //                 ConnectionString
            //                 , dt
            //                 , null
            //                 , "proc_Atheniticate_Hotel"
            //                 , new SqlParameter[] { new SqlParameter("@xml", xml.InnerXml), 
            //                                        new SqlParameter("@type", 1) 
            //                                       }
            //                 , null
            //                 , 500
            //                 );

            //if (param.Value.ToString() != null)
            //{

            //}

            NGODBEntities obj = new NGODBEntities();

           

            return lst;
        }


    }
}