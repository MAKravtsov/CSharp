﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "okay";
        }
    }
}