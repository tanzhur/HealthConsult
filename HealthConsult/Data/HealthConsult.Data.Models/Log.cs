namespace HealthConsult.Data.Models
{
    using System;
    using HealthConsult.Contracts;

    public class Log : DeletableEntity
    {
        public int Id { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
