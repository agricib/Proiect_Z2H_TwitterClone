﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestChat.Controllers
{
    public class MapController : Controller
    {
        //
        // GET: /Map/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SimpleMap()
        {
            return View();
        }
   
    }
}