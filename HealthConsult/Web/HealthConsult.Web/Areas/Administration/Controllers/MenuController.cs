namespace HealthConsult.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using HealthConsult.Common;
    using HealthConsult.Data;
    using HealthConsult.Data.Models.Enumerations;
    using HealthConsult.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class MenuController : BaseController
    {
        public MenuController(IApplicationData data)
        {
            this.data = data;
        }

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

        public ActionResult Specialists()
        {
            IEnumerable<SelectListItem> specialities = this.data.Specialities.All()
                                                           .Select(c => new SelectListItem
                                                                  {
                                                                      Value = c.Id.ToString(),
                                                                      Text = c.Name
                                                                  });
            this.ViewBag.Specialties = specialities;

            IEnumerable<SelectListItem> hospitals = this.data.Hospitals.All()
                                                        .Select(c => new SelectListItem
                                                               {
                                                                   Value = c.Id.ToString(),
                                                                   Text = c.Name
                                                               });
            this.ViewBag.Hospitals = hospitals;

            

            var titles = Enum.GetValues(typeof(Title)).Cast<Title>().Select(v => new SelectListItem
            {
                Text = v.ToDescription<Title>(),
                Value = ((int)v).ToString()
            });

            this.ViewBag.Titles = titles;

            return this.View();
        }
    }
}