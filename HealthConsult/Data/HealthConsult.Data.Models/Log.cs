namespace HealthConsult.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HealthConsult.Contracts;
    using HealthConsult.Data.Models.Enumerations;


    public class Log : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User {get; set;}

        [Required]
        public DateTime ActionDate { get; set; }

        [Required]
        public ActionType Action { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
