namespace HealthConsult.Web.Areas.Administration.Models
{
    using HealthConsult.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using HealthConsult.Web.Infrastructure.Mapping;

    public class HospitalViewModel: IMapFrom<Hospital>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}