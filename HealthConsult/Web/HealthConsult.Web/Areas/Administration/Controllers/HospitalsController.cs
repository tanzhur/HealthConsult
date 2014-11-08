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

    public class HospitalsController : AdminController
    {
        public HospitalsController(IApplicationData data, ILogger logger)
        {
            this.data = data;
            this.logger = logger;
        }

        public JsonResult ReadHospitals([DataSourceRequest]
                                        DataSourceRequest request)
        {
            var result = this.data.Hospitals.All().AsQueryable()
                             .Project()
                             .To<HospitalViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHospital([DataSourceRequest]
                                           DataSourceRequest request, HospitalViewModel hospitalModel)
        {
            if (hospitalModel != null && this.ModelState.IsValid)
            {
                hospitalModel.Longitude = "0";
                hospitalModel.Latitude = "0";
                var hospital = new Hospital();
                Mapper.Map(hospitalModel, hospital, typeof(HospitalViewModel), typeof(Hospital));
                this.data.Hospitals.Add(hospital);
                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.AddHospital, hospitalModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateHospital([DataSourceRequest]
                                           DataSourceRequest request, HospitalViewModel hospitalModel)
        {
            if (hospitalModel != null && this.ModelState.IsValid)
            {
                hospitalModel.Longitude = "0";
                hospitalModel.Latitude = "0";
                var hospital = this.data.Hospitals.All().FirstOrDefault(h => h.Id == hospitalModel.Id);
                Mapper.Map(hospitalModel, hospital, typeof(HospitalViewModel), typeof(Hospital));
                this.data.Hospitals.Update(hospital);
                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.EditHospital, hospitalModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHospital([DataSourceRequest]
                                           DataSourceRequest request, HospitalViewModel hospitalModel)
        {
            if (hospitalModel != null)
            {
                var hospital = this.data.Hospitals.All().FirstOrDefault(h => h.Id == hospitalModel.Id);
                hospital.Deleted = true;
                hospital.DeletedOn = DateTime.Now;
                this.data.Hospitals.Update(hospital);
                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.DeleteHospital, hospitalModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, this.ModelState));
        }

        private void GetLocation()
        {
            ViewBag.Latitude = 0;
            ViewBag.Longitude = 0;
        }
    }
}