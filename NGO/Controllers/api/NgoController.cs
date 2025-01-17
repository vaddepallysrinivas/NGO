﻿using NGO.BusinessLayer;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NGO.Controllers.api
{
    [RoutePrefix("ngodata")]
    public class NgoController : ApiController
    {

        NgoDataOperations obj;
        public NgoController()
        {
            obj = new NgoDataOperations();
        }


        #region notifications
        [Route("crudNotification")]
        [HttpPost]
        public int crudNotification([FromBody] Notification objNotification)
        {
            obj.CrudNotification(objNotification);
            return 1;
        }

        [Route("getNotificationsList")]
        public IEnumerable<Notification> GetNotificationsList()
        {

            return obj.GetNotificationsList();
        }
        [Route("getNotificationCode")]
        public string GetNotificationCode()
        {

            return obj.GetNotificationCode();
        }

        [Route("getDistricts")]
        public IEnumerable<District> GetDistricts()
        {
            return obj.GetDistricts();
        }

        [HttpPost]
        [Route("loadZones")]
        public IEnumerable<Zone> LoadZones([FromBody]IteamID DistrictID)
        {
            return obj.GetZones(DistrictID);
        }

        [HttpPost]
        [Route("loadMandals")]
        public IEnumerable<Mandal> LoadMandals([FromBody]IteamID ZoneID)
        {
            return obj.GetMandals(ZoneID);
        }


        #endregion

        #region zone
        [Route("getZoneList")]
        public IEnumerable<Zone> getZoneList()
        {

            return obj.getZoneList();
        }

        //[Route("getZoneCode")]
        //public string GetZoneCode()
        //{

        //    return obj.GetZoneCode();
        //}

        #endregion
    }
}