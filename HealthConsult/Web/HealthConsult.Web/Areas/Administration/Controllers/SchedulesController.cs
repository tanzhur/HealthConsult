using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthConsult.Web.Areas.Administration.Controllers
{
    public class SchedulesController : Controller
    {
        // GET: Administration/Schedules
        public ActionResult Index()
        {
            return View();
        }
    }
}