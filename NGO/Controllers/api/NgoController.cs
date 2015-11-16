using NGO.BusinessLayer;
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
        [Route("insertNotification")]
        [HttpPost]
        public int  InsertNotification([FromBody] Notification obj)
        {

            return 1;
        }

        [Route("getNotificationsList")]
        public IEnumerable<Notification> GetNotificationsList()
        {

            return obj.GetNotificationsList();
        }

        #endregion


    }
}