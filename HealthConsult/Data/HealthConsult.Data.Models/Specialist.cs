namespace HealthConsult.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HealthConsult.Contracts;
    using HealthConsult.Data.Models.Enumerations;

    public class Specialist : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Title Title { get; set; }

        public string Phone { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        [Required]
        public int HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}