namespace HealthConsult.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using HealthConsult.Data.Models.Enumerations;

    public class Specialist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Title Title { get; set; }

        public string Phone { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        [Required]
        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}