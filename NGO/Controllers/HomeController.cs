﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace NGO.Controllers
{
    public class HomeController : Controller
    {
        // GET api/<controller>
        public ActionResult Index()
        {
            return View();
        }
    }
}