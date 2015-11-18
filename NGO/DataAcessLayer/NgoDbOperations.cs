﻿using NGO.Models;
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

        public IEnumerable<District> GetDistricts()
        {
            List<District> result = lobj1.tbl_District.Select(x => new District() { Code = x.Code, DistrictName = x.DistrictName }).ToList();
            return result;
        }
        public IEnumerable<Zone> GetZone(IteamID DistrictID)
        {
            List<Zone> result = lobj1.tbl_Zone.Select(x => new Zone() { Code = x.Code, ZoneName = x.ZoneName }).ToList();
            return result;
        }
        public IEnumerable<Mandal> GetMandal(IteamID ZoneID)
        {
            List<Mandal> result = lobj1.tbl_Mandal.Where(x => x.Code == ZoneID.ID).Select(x => new Mandal() { Code = x.Code, MandalName = x.MandalName }).ToList();
            return result;
        }
    }
}