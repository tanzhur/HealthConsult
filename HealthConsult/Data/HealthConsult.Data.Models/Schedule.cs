namespace HealthConsult.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int SpecialistId { get; set; }

        public virtual Specialist Specialist { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public DateTime EndingDate { get; set; }
    }
}
