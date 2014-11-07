namespace HealthConsult.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class DeletableEntity : IDeletableEntity
    {
        [Display(Name = "Deleted?")]
        [Editable(false)]
        public bool Deleted { get; set; }

        [Display(Name = "Deletion date")]
        [Editable(false)]
        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
