namespace HealthConsult.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HealthConsult.Contracts;

    public class Diagnosis : DeletableEntity
    {
        [Key]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}