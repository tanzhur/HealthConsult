namespace HealthConsult.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using HealthConsult.Data;
    using HealthConsult.Web.Areas.Administration.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class LogsController : AdminController
    {
        public LogsController(IApplicationData data)
        {
            this.data = data;
        }

        public JsonResult ReadLogs([DataSourceRequest]
                                        DataSourceRequest request)
        {
            var result = this.data.Logs.All()
                .OrderByDescending(l => l.ActionDate)
                .AsQueryable()
                             .Project()
                             .To<LogViewModel>().ToList();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}