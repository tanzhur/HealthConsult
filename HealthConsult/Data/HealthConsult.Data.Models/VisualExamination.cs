namespace HealthConsult.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HealthConsult.Data.Models.Enumerations;

    public class VisualExamination
    {
        public int Id { get; set; }

        [Required]
        public int ConsultationId { get; set; }

        public Consultation Consultation { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public ExaminationType Type { get; set; }

        public string InputInformation { get; set; }

        public string ConsultInformation { get; set; }

        [Required]
        public byte[] FileContent { get; set; }

        [Required]
        public string FileType { get; set; }
    }
}