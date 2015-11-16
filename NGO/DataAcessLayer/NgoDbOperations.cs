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

        private DBLibrary.DBLibrary lobj = new DBLibrary.DBLibrary();
        private NGODBEntities lobj1 = new NGODBEntities();
        private DataTable dt;
        private XmlDocument xml;
        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ngoConstring"].ToString();

        public IEnumerable<Notification> GetNotificationsList()
        {




            var result = lobj1.Database.SqlQuery<Notification>("exec proc_Notifications @xml=null,@type=3").ToList();

            return result;
        }


    }
}