namespace HealthConsult.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using HealthConsult.Data;

    public class BaseController : Controller
    {
        public IApplicationData data;

        public BaseController()
        {

        }

        public BaseController(IApplicationData data)
        {
            this.data = data;
        }
    }
}