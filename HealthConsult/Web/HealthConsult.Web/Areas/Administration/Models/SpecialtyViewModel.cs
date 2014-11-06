namespace HealthConsult.Web.Areas.Administration.Models
{
    using HealthConsult.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using HealthConsult.Web.Infrastructure.Mapping;
    using AutoMapper;

    public class SpecialtyViewModel : IMapFrom<Speciality>
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
    }
}