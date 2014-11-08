namespace HealthConsult.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data.Models;
    using System.Globalization;

    public class HospitalViewModel
    {
        public HospitalViewModel()
        {
            Mapper.CreateMap<HospitalViewModel, Hospital>()
                .ForMember(h => h.Latitude, opt => opt.MapFrom(h => decimal.Parse(h.Latitude, CultureInfo.InvariantCulture)))
                .ForMember(h => h.Longitude, opt => opt.MapFrom(h => decimal.Parse(h.Longitude, CultureInfo.InvariantCulture)));
            Mapper.CreateMap<HospitalViewModel, Hospital>().ReverseMap()
                .ForMember(h => h.Latitude, opt => opt.MapFrom(h => h.Latitude.ToString()))
                .ForMember(h => h.Longitude, opt => opt.MapFrom(h => h.Longitude.ToString()));
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}