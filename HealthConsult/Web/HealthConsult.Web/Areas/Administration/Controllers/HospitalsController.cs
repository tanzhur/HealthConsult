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

    public class HospitalsController : BaseController
    {
        public HospitalsController(IApplicationData data)
        {
            this.data = data;
        }

        public JsonResult ReadHospitals([DataSourceRequest]
                                        DataSourceRequest request)
        {
            var result = this.data.Hospitals.All().AsQueryable();
            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateHospital([DataSourceRequest]
                                           DataSourceRequest request, HospitalViewModel hospitalModel)
        {
            if (hospitalModel != null && this.ModelState.IsValid)
            {
                var hospital = new Hospital();
                Mapper.Map(hospitalModel, hospital, typeof(HospitalViewModel), typeof(Hospital));
                this.data.Hospitals.Add(hospital);
                this.data.SaveChanges();
            }

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateHospital([DataSourceRequest]
                                           DataSourceRequest request, HospitalViewModel hospitalModel)
        {
            if (hospitalModel != null && this.ModelState.IsValid)
            {
                var hospital = this.data.Hospitals.All().FirstOrDefault(h => h.Id == hospitalModel.Id);
                Mapper.Map(hospitalModel, hospital, typeof(HospitalViewModel), typeof(Hospital));
                this.data.Hospitals.Update(hospital);
                this.data.SaveChanges();
            }

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteHospital([DataSourceRequest]
                                           DataSourceRequest request, HospitalViewModel hospitalModel)
        {
            if (hospitalModel != null)
            {
                var hospital = this.data.Hospitals.All().FirstOrDefault(h => h.Id == hospitalModel.Id);

                this.data.Hospitals.Delete(hospital);

                this.data.SaveChanges();
            }

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}