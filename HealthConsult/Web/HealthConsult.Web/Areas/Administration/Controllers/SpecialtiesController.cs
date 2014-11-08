namespace HealthConsult.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HealthConsult.Data;
    using HealthConsult.Data.Models;
    using HealthConsult.Data.Models.Enumerations;
    using HealthConsult.Web.Areas.Administration.Models;
    using HealthConsult.Web.Infrastructure.Logging;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class SpecialtiesController : AdminController
    {
        public SpecialtiesController(IApplicationData data, ILogger logger)
        {
            this.data = data;
            this.logger = logger;
        }

        public JsonResult ReadSpecialties([DataSourceRequest]
                                          DataSourceRequest request)
        {
            var result = this.data.Specialities.All().AsQueryable()
                             .Project()
                             .To<SpecialtyViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSpecialties([DataSourceRequest]
                                              DataSourceRequest request, SpecialtyViewModel specialtyModel)
        {
            if (specialtyModel != null && this.ModelState.IsValid)
            {
                var specialty = new Speciality();
                Mapper.Map(specialtyModel, specialty, typeof(SpecialtyViewModel), typeof(Speciality));
                this.data.Specialities.Add(specialty);
                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.AddSpecialty, specialtyModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { specialtyModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSpecialties([DataSourceRequest]
                                              DataSourceRequest request, SpecialtyViewModel specialtyModel)
        {
            if (specialtyModel != null && this.ModelState.IsValid)
            {
                var specialty = this.data.Specialities.All().FirstOrDefault(h => h.Id == specialtyModel.Id);
                Mapper.Map(specialtyModel, specialty, typeof(SpecialtyViewModel), typeof(Speciality));
                this.data.Specialities.Update(specialty);
                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.EditSpecialty, specialtyModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { specialtyModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSpecialties([DataSourceRequest]
                                              DataSourceRequest request, SpecialtyViewModel specialtyModel)
        {
            if (specialtyModel != null)
            {
                var specialty = this.data.Specialities.All().FirstOrDefault(h => h.Id == specialtyModel.Id);
                specialty.Deleted = true;
                specialty.DeletedOn = DateTime.Now;
                this.data.Specialities.Update(specialty);
                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.DeleteSpecialty, specialtyModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { specialtyModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}