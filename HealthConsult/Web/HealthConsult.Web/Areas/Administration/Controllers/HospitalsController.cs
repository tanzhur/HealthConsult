namespace HealthConsult.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using HealthConsult.Data;
    using HealthConsult.Data.Models;
    using HealthConsult.Web.Areas.Administration.Models;
    using HealthConsult.Web.Controllers;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using AutoMapper;

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
                var hospital = new Hospital
                {
                    Name = hospitalModel.Name,
                    Address = hospitalModel.Address,
                    Phone = hospitalModel.Phone,
                    Latitude = hospitalModel.Latitude,
                    Longitude = hospitalModel.Longitude
                };

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

                //var hospital = Mapper.Map<Hospital>(hospitalModel);

                hospital.Name = hospitalModel.Name;
                hospital.Address = hospitalModel.Address;
                hospital.Phone = hospitalModel.Phone;
                hospital.Latitude = hospitalModel.Latitude;
                hospital.Longitude = hospitalModel.Longitude;

                this.data.Hospitals.Update(hospital);

                this.data.SaveChanges();
            }

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, ModelState));
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

            return this.Json(new[] { hospitalModel }.ToDataSourceResult(request, ModelState));
        }
    }
}