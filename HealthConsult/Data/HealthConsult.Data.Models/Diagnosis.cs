namespace HealthConsult.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Diagnosis
    {
        [Key]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
