namespace HealthConsult.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data;
    using HealthConsult.Data.Models;
    using HealthConsult.Web.Areas.Administration.Models;
    using HealthConsult.Web.Controllers;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class SpecialtiesController : BaseController
    {

        public SpecialtiesController(IApplicationData data)
        {
            this.data = data;
        }

        public JsonResult ReadSpecialties([DataSourceRequest]
                                        DataSourceRequest request)
        {
            var result = this.data.Specialities.All().AsQueryable();
            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateSpecialties([DataSourceRequest]
                                           DataSourceRequest request, SpecialtyViewModel specialtyModel)
        {
            if (specialtyModel != null && this.ModelState.IsValid)
            {
                var specialty = new Speciality();
                Mapper.Map(specialtyModel, specialty, typeof(SpecialtyViewModel), typeof(Speciality));
                this.data.Specialities.Add(specialty);
                this.data.SaveChanges();
            }

            return this.Json(new[] { specialtyModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateSpecialties([DataSourceRequest]
                                           DataSourceRequest request, SpecialtyViewModel specialtyModel)
        {
            if (specialtyModel != null && this.ModelState.IsValid)
            {
                var specialty = this.data.Specialities.All().FirstOrDefault(h => h.Id == specialtyModel.Id);
                Mapper.Map(specialtyModel, specialty, typeof(SpecialtyViewModel), typeof(Speciality));
                this.data.Specialities.Update(specialty);
                this.data.SaveChanges();
            }

            return this.Json(new[] { specialtyModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteSpecialties([DataSourceRequest]
                                           DataSourceRequest request, SpecialtyViewModel specialtyModel)
        {
            if (specialtyModel != null)
            {
                var specialty = this.data.Specialities.All().FirstOrDefault(h => h.Id == specialtyModel.Id);

                this.data.Specialities.Delete(specialty);

                this.data.SaveChanges();
            }

            return this.Json(new[] { specialtyModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}