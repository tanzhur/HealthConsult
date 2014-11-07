namespace HealthConsult.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HealthConsult.Contracts;

    public class Schedule : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public int SpecialistId { get; set; }

        public virtual Specialist Specialist { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public DateTime EndingDate { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}