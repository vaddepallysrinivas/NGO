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

        public IEnumerable<Districts> GetDistricts()
        {
            List<Districts> result = lobj1.tbl_District.Select(x => new Districts() { Code = x.Code, DistrictName = x.DistrictName }).ToList();
            return result;
        }
        public IEnumerable<Zones> GetZone(IteamID DistrictID)
        {
            List<Zones> result = lobj1.tbl_Zone.Select(x => new Zones() { Code = x.Code, ZoneName = x.ZoneName }).ToList();
            return result;
        }
        public IEnumerable<Mandals> GetMandal(IteamID ZoneID)
        {
            List<Mandals> result = lobj1.tbl_Mandal.Where(x => x.Code == ZoneID.ID).Select(x => new Mandals() { Code = x.Code, MandalName = x.MandalName }).ToList();
            return result;
        }
    }
}