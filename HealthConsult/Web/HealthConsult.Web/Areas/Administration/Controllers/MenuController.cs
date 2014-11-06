namespace HealthConsult.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using HealthConsult.Common;
    using HealthConsult.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class MenuController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Hospitals()
        {
            return this.View();
        }

        public ActionResult Specialties()
        {
            return this.View();
        }
    }
}