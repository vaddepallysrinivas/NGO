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
        private XmlDocument xmlDoc;
        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ngoConstring"].ToString();

        #region norifications
        public void CrudNotification(Notification objNotification)
        {

            //create XML Document Class objct
            xmlDoc = new XmlDocument();
            //creating header tag
            xmlDoc = XMLdoc.CreateXmlHeading(xmlDoc);

            //--------------creating elements with data in header roor------------
            xmlDoc = XMLdoc.AddXmlElement(xmlDoc, "notificationid", objNotification.NotificationId.ToString());
            xmlDoc = XMLdoc.AddXmlElement(xmlDoc, "code", objNotification.Code);
            xmlDoc = XMLdoc.AddXmlElement(xmlDoc, "notificationtext", objNotification.NotificationText);
            xmlDoc = XMLdoc.AddXmlElement(xmlDoc, "createdby", objNotification.CreatedBy.ToString());
            xmlDoc = XMLdoc.AddXmlElement(xmlDoc, "modifiedby", objNotification.ModifiedBy.ToString());
            xmlDoc = XMLdoc.AddXmlElement(xmlDoc, "feeamount", objNotification.FeeAmount.ToString());
            xmlDoc = XMLdoc.AddXmlElement(xmlDoc, "isactive", objNotification.IsActive.ToString());

            //-----------creating elements with data in header roo-----------------------------------

            SqlParameter param = new SqlParameter("@err_msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;

            lobj1.Database.ExecuteSqlCommand("proc_Notifications @xml,@type,@err_msg out",
                new SqlParameter("@xml", xmlDoc.InnerXml),
                  new SqlParameter("@type", objNotification.Type),
                  param
                );




        }

        public IEnumerable<Notification> GetNotificationsList()
        {
            List<Notification> result;
            using (lobj1)
            {
                result = lobj1.tbl_Notifications.Select(x => new Notification()
                {
                    Code = x.code,
                    NotificationText = x.NotificationText,
                    FeeAmount = x.FeeAmount,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    ModifiedBy = x.ModifiedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    Del_ind = x.Del_ind

                }).Where(s => s.Del_ind == false).ToList();
            }
            return result;

        }

        public string GetNotificationCode()
        {
            SqlParameter param = new SqlParameter("@err_msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;

            return lobj1.Database.SqlQuery<string>("proc_Notifications @xml,@type,@err_msg out",
                new SqlParameter("@xml", ""),
                  new SqlParameter("@type", 5),
                  param
                ).Single();

        }

        #endregion



        #region Zones
        public IEnumerable<Zone> getZoneList()
        {
            List<Zone> result;
            using (lobj1)
            {
                result = lobj1.tbl_Zone.Select(x => new Zone()
                {
                    Code = x.Code,
                    ZoneName = x.ZoneName,
                    CreatedBy = x.CreatedBy,
                    ModifiedBy = x.ModifiedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedDate = x.ModifiedDate,
                    Del_ind = x.Del_ind

                }).Where(s => s.Del_ind == false).ToList();
            }
            return result;

        }




        public string GetZoneCode()
        {
            SqlParameter param = new SqlParameter("@err_msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;

            return lobj1.Database.SqlQuery<string>("proc_Notifications @xml,@type,@err_msg out",
                new SqlParameter("@xml", ""),
                  new SqlParameter("@type", 5),
                  param
                ).Single();

        }




        #endregion

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