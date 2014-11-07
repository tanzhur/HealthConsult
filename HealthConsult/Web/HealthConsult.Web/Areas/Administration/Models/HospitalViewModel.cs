namespace HealthConsult.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data.Models;

    public class HospitalViewModel
    {
        public HospitalViewModel()
        {
            Mapper.CreateMap<HospitalViewModel, Hospital>();
            Mapper.CreateMap<HospitalViewModel, Hospital>().ReverseMap();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}