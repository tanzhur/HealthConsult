namespace HealthConsult.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using HealthConsult.Common;
    using HealthConsult.Data;
    using HealthConsult.Data.Models;
    using HealthConsult.Web.Areas.Administration.Models;
    using HealthConsult.Web.Infrastructure.Logging;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using HealthConsult.Data.Models.Enumerations;

    public class SpecialistsController : AdminController
    {
        public SpecialistsController(IApplicationData data, ILogger logger)
        {
            this.data = data;
            this.logger = logger;
        }

        public JsonResult ReadSpecialists([DataSourceRequest]
                                          DataSourceRequest request)
        {
            var result = this.data.Specialists.All().AsQueryable()
                             .Project()
                             .To<SpecialistViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSpecialist([DataSourceRequest]
                                             DataSourceRequest request, SpecialistViewModel specialistModel)
        {
            if (specialistModel != null && this.ModelState.IsValid)
            {
                var context = new ApplicationDbContext();
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = specialistModel.Username };

                manager.Create(user, GlobalConstants.InitialPassword);
                manager.AddToRole(user.Id, GlobalConstants.SpecialistRoleName);

                var specialist = new Specialist();
                specialist.UserId = user.Id;
                Mapper.Map(specialistModel, specialist, typeof(SpecialistViewModel), typeof(Specialist));
                this.data.Specialists.Add(specialist);

                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.AddSpecialist, specialistModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { specialistModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSpecialist([DataSourceRequest]
                                             DataSourceRequest request, SpecialistViewModel specialistModel)
        {
            if (specialistModel != null && this.ModelState.IsValid)
            {
                var specialist = this.data.Specialists.All().FirstOrDefault(s => s.Id == specialistModel.Id);
                Mapper.Map(specialistModel, specialist, typeof(SpecialistViewModel), typeof(Specialist));
                this.data.Specialists.Update(specialist);
                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.EditSpecialist, specialistModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { specialistModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult DeleteSpecialist([DataSourceRequest]
                                             DataSourceRequest request, SpecialistViewModel specialistModel)
        {
            if (specialistModel != null)
            {
                var specialist = this.data.Specialists.All().FirstOrDefault(s => s.Id == specialistModel.Id);
                specialist.Deleted = true;
                specialist.DeletedOn = DateTime.Now;
                this.data.Specialists.Update(specialist);

                var user = this.data.Users.All().FirstOrDefault(u => u.UserName == specialistModel.Username);
                user.Deleted = true;
                user.DeletedOn = DateTime.Now;
                this.data.Users.Update(user);

                this.data.SaveChanges();

                this.logger.Log(this.data, ActionType.DeleteSpecialist, specialistModel.Name, this.GetUserId(this.User.Identity.Name));
            }

            return this.Json(new[] { specialistModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}