namespace HealthConsult.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hospital
    {
        private ICollection<Specialist> specialists;

        public Hospital()
        {
            this.specialists = new HashSet<Specialist>(); 
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public virtual ICollection<Specialist> Specialists
        {
            get
            {
                return this.specialists;
            }

            set
            {
                this.specialists = value;
            }
        }
    }
}
