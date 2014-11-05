namespace HealthConsult.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Speciality
    {
        public Speciality()
        {
            this.Specialists = new HashSet<Specialist>(); 
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Specialist> Specialists { get; set; }
    }
}