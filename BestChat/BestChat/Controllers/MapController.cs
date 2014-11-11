using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapExample.Controllers
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
        public ActionResult HeatMap()
        {
            return View();
        }
        public ActionResult SignalR()
        {
            return View();
        }
    }
}