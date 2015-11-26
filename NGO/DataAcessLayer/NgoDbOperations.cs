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

        internal bool SaveTeacherDetails(TeacherDetails Teacher, out TeacherRegDetails objDetails)
        {
            var p_firstName = new SqlParameter();
            p_firstName.ParameterName = "p_firstName";
            p_firstName.Direction = ParameterDirection.Input;
            p_firstName.SqlDbType = SqlDbType.VarChar;
            p_firstName.Value = (string.IsNullOrEmpty(Teacher.FirstName)) ? (object)DBNull.Value : Teacher.FirstName;
            p_firstName.IsNullable = true;

            var p_middleName = new SqlParameter();
            p_middleName.ParameterName = "p_middleName";
            p_middleName.Direction = ParameterDirection.Input;
            p_middleName.SqlDbType = SqlDbType.VarChar;
            p_middleName.Value = (string.IsNullOrEmpty(Teacher.MiddleName)) ? (object)DBNull.Value : Teacher.MiddleName;
            p_middleName.IsNullable = true;

            var p_lastName = new SqlParameter();
            p_lastName.ParameterName = "p_lastName";
            p_lastName.Direction = ParameterDirection.Input;
            p_lastName.SqlDbType = SqlDbType.VarChar;
            p_lastName.Value = (string.IsNullOrEmpty(Teacher.LastName)) ? (object)DBNull.Value : Teacher.LastName;
            p_lastName.IsNullable = true;

            var p_email = new SqlParameter();
            p_email.ParameterName = "p_email";
            p_email.Direction = ParameterDirection.Input;
            p_email.SqlDbType = SqlDbType.VarChar;
            p_email.Value = (string.IsNullOrEmpty(Teacher.Email)) ? (object)DBNull.Value : Teacher.Email;
            p_email.IsNullable = true;

            var p_selectedGenderId = new SqlParameter();
            p_selectedGenderId.ParameterName = "p_selectedGenderId";
            p_selectedGenderId.Direction = ParameterDirection.Input;
            p_selectedGenderId.SqlDbType = SqlDbType.VarChar;
            p_selectedGenderId.Value = (string.IsNullOrEmpty(Teacher.SelectedGenderId)) ? (object)DBNull.Value : Teacher.SelectedGenderId;
            p_selectedGenderId.IsNullable = true;

            var p_contactno = new SqlParameter();
            p_contactno.ParameterName = "p_contactno";
            p_contactno.Direction = ParameterDirection.Input;
            p_contactno.SqlDbType = SqlDbType.VarChar;
            p_contactno.Value = (string.IsNullOrEmpty(Teacher.Contactno)) ? (object)DBNull.Value : Teacher.Contactno;
            p_contactno.IsNullable = true;

            var p_schoolName = new SqlParameter();
            p_schoolName.ParameterName = "p_schoolName";
            p_schoolName.Direction = ParameterDirection.Input;
            p_schoolName.SqlDbType = SqlDbType.VarChar;
            p_schoolName.Value = (string.IsNullOrEmpty(Teacher.SchoolName)) ? (object)DBNull.Value : Teacher.SchoolName;
            p_schoolName.IsNullable = true;

            var p_schoolAdd = new SqlParameter();
            p_schoolAdd.ParameterName = "p_schoolAdd";
            p_schoolAdd.Direction = ParameterDirection.Input;
            p_schoolAdd.SqlDbType = SqlDbType.VarChar;
            p_schoolAdd.Value = (string.IsNullOrEmpty(Teacher.SchoolAdd)) ? (object)DBNull.Value : Teacher.SchoolAdd;
            p_schoolAdd.IsNullable = true;

            var p_schoolDistrictId = new SqlParameter();
            p_schoolDistrictId.ParameterName = "p_schoolDistrictId";
            p_schoolDistrictId.Direction = ParameterDirection.Input;
            p_schoolDistrictId.SqlDbType = SqlDbType.VarChar;
            p_schoolDistrictId.Value = (string.IsNullOrEmpty(Teacher.SchoolDistrictId)) ? (object)DBNull.Value : Teacher.SchoolDistrictId;
            p_schoolDistrictId.IsNullable = true;

            var p_ScholZoneId = new SqlParameter();
            p_ScholZoneId.ParameterName = "p_ScholZoneId";
            p_ScholZoneId.Direction = ParameterDirection.Input;
            p_ScholZoneId.SqlDbType = SqlDbType.VarChar;
            p_ScholZoneId.Value = (string.IsNullOrEmpty(Teacher.ScholZoneId)) ? (object)DBNull.Value : Teacher.ScholZoneId;
            p_ScholZoneId.IsNullable = true;

            var p_schoolMandalid = new SqlParameter();
            p_schoolMandalid.ParameterName = "p_schoolMandalid";
            p_schoolMandalid.Direction = ParameterDirection.Input;
            p_schoolMandalid.SqlDbType = SqlDbType.VarChar;
            p_schoolMandalid.Value = (string.IsNullOrEmpty(Teacher.SchoolMandalid)) ? (object)DBNull.Value : Teacher.SchoolMandalid;
            p_schoolMandalid.IsNullable = true;

            var p_schoolVillage = new SqlParameter();
            p_schoolVillage.ParameterName = "p_schoolVillage";
            p_schoolVillage.Direction = ParameterDirection.Input;
            p_schoolVillage.SqlDbType = SqlDbType.VarChar;
            p_schoolVillage.Value = (string.IsNullOrEmpty(Teacher.SchoolVillage)) ? (object)DBNull.Value : Teacher.SchoolVillage;
            p_schoolVillage.IsNullable = true;

            var result = lobj1.Database.SqlQuery<TeacherRegDetails>(@"proc_TeacherReg @p_firstName, @p_middleName,@p_lastName,
                            @p_email,@p_selectedGenderId,@p_contactno,@p_schoolName,@p_schoolAdd,@p_schoolDistrictId,
                            @p_ScholZoneId,@p_schoolMandalid,@p_schoolVillage", p_firstName, p_middleName, p_lastName,
                            p_email, p_selectedGenderId, p_contactno, p_schoolName, p_schoolAdd, p_schoolDistrictId,
                            p_ScholZoneId, p_schoolMandalid, p_schoolVillage).ToList();
            objDetails = result.SingleOrDefault();
            return result.Count() > 0;
        }
    }
}