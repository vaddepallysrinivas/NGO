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

        [Route("insertNotification")]
        [HttpPost]
        public int  InsertNotification([FromBody] Notification obj)
        {

            return 1;
        }

      
    }
}