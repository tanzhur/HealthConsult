namespace HealthConsult.Web.Areas.Administration.Models
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data.Models;

    public class LogViewModel
    {
        public LogViewModel()
        {
            Mapper.CreateMap<LogViewModel, Log>()
                  .ReverseMap()
                  .ForMember(s => s.Date, opt => opt.MapFrom(l => l.ActionDate.ToString()))
                  .ForMember(s => s.Action, opt => opt.MapFrom(l => l.Action.ToString()))
                  .ForMember(s => s.Username, opt => opt.MapFrom(l => l.User.UserName));
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Date { get; set; }

        public string Username { get; set; }

        public string Action { get; set; }

        public string ActionInfo { get; set; }
    }
}