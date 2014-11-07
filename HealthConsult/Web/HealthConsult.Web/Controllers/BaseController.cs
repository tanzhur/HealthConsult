namespace HealthConsult.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using HealthConsult.Data;
    using HealthConsult.Web.Infrastructure.Logging;

    public class BaseController : Controller
    {
        protected IApplicationData data;
        protected ILogger logger;

        public BaseController()
        {
        }

        public BaseController(IApplicationData data, ILogger logger)
        {
            this.data = data;
            this.logger = logger;
        }
    }
}