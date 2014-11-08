namespace HealthConsult.Web.Areas.Administration.Models
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data.Models;
    using Kendo.Mvc.UI;

    public class ScheduleViewModel : ISchedulerEvent
    {
        public ScheduleViewModel()
        {
            Mapper.CreateMap<ScheduleViewModel, Schedule>();
            Mapper.CreateMap<ScheduleViewModel, Schedule>()
                  .ReverseMap()
                  .ForMember(s => s.SpecialistName, opt => opt.MapFrom(s => s.Specialist.Name));
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int SpecialistId { get; set; }

        public string SpecialistName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string StartTimezone { get; set; }

        public string EndTimezone { get; set; }

        public bool IsAllDay { get; set; }

        public string RecurrenceException { get; set; }

        public string RecurrenceRule { get; set; }
    }
}