namespace HealthConsult.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}