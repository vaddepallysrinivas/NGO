using NGO.DataAcessLayer;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.BusinessLayer
{
    public class NgoDataOperations
    {
        NgoDbOperations obj;

        public NgoDataOperations()
        {
            obj = new NgoDbOperations();
        }
        #region Notifications
        public IEnumerable<Notification> GetNotificationsList()
        {
            return obj.GetNotificationsList();
        }

        public void CrudNotification(Notification objNotification)
        {
            obj.CrudNotification(objNotification);
        }

        internal string GetNotificationCode()
        {
            return obj.GetNotificationCode();
        }

        #endregion


        #region Zones
        public IEnumerable<Zone> getZoneList()
        {
            return obj.getZoneList();
        }

        //public void CrudNotification(Notification objNotification)
        //{
        //    obj.CrudNotification(objNotification);
        //}

        //internal string GetNotificationCode()
        //{
        //    return obj.GetZoneCode();
        //}

        #endregion


        internal IEnumerable<District> GetDistricts()
        {
            return obj.GetDistricts();
        }

        internal IEnumerable<Zone> GetZones(Models.IteamID DistrictID)
        {
            return obj.GetZone(DistrictID);
        }

        internal IEnumerable<Mandal> GetMandals(IteamID ZoneID)
        {
            return obj.GetMandal(ZoneID);
        }

        internal bool SaveTeacherDetails(TeacherDetails Teacher, out TeacherRegDetails objDetails)
        {
            return obj.SaveTeacherDetails(Teacher, out  objDetails);
        }
    }
}