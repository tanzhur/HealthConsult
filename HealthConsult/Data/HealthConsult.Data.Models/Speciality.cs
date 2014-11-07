namespace HealthConsult.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HealthConsult.Contracts;

    public class Speciality : DeletableEntity
    {
        public Speciality()
        {
            this.Specialists = new HashSet<Specialist>(); 
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Specialist> Specialists { get; set; }
    }
}