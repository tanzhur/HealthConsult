namespace HealthConsult.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using HealthConsult.Data.Models;
    using System.ComponentModel;
    using HealthConsult.Data.Models.Enumerations;
    using System;

    public class SpecialistViewModel
    {
        public SpecialistViewModel()
        {
            Mapper.CreateMap<SpecialistViewModel, Specialist>()
                .ForMember(s => s.Title, opt => opt.MapFrom(t => (Title)t.Title));

            Mapper.CreateMap<SpecialistViewModel, Specialist>().ReverseMap()
                .ForMember(s => s.SpecialityName, opt => opt.MapFrom(u => u.Speciality.Name))
                .ForMember(s => s.HospitalName, opt => opt.MapFrom(u => u.Hospital.Name))
                .ForMember(s => s.TitleAndName, opt => opt.MapFrom(u => u.Title.ToString() + " " + u.Name))
                .ForMember(s => s.Username, opt => opt.MapFrom(u => u.User.UserName))
                .ForMember(s => s.Title, opt => opt.MapFrom(u => (int)u.Title));
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Title { get; set; }

        [DisplayName("Specialist")]
        public string TitleAndName { get; set; }

        public string Phone { get; set; }

        [Required]
        [DisplayName("Speciality")]
        public int SpecialityId { get; set; }

        public string SpecialityName { get; set; }

        [Required]
        [DisplayName("Hospital")]
        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        [Required]
        public string Username { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}