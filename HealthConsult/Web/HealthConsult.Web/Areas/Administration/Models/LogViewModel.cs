﻿namespace HealthConsult.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data.Models;
    using HealthConsult.Common;
    using HealthConsult.Data.Models.Enumerations;

    public class LogViewModel
    {
        public LogViewModel()
        {
            Mapper.CreateMap<LogViewModel, Log>()
                  .ReverseMap()
                  .ForMember(s => s.Date, opt => opt.MapFrom(u => u.ActionDate.ToString()))
                  .ForMember(s => s.Action, opt => opt.MapFrom(u => u.Action.ToString()))
                  .ForMember(s => s.Username, opt => opt.MapFrom(u => u.User.UserName));
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Date { get; set; }

        public string Username { get; set; }

        public string Action { get; set; }
    }
}