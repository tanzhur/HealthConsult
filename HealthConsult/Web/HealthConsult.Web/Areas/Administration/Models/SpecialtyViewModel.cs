namespace HealthConsult.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data.Models;

    public class SpecialtyViewModel
    {
        public SpecialtyViewModel()
        {
            Mapper.CreateMap<SpecialtyViewModel, Speciality>();
            Mapper.CreateMap<SpecialtyViewModel, Speciality>().ReverseMap();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}