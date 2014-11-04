namespace HealthConsult.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BloodExamination
    {
        public int Id { get; set; }

        [Required]
        public int ConsultationId { get; set; }

        public Consultation Consultation { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public double Hemoglobin { get; set; }

        public double Erythrocytes { get; set; }

        public double Hct { get; set; }

        public double Leuc { get; set; }

        public double Mchc { get; set; }

        public double Mch { get; set; }

        public double Mcv { get; set; }

        public double Ret { get; set; }

        public double Sue { get; set; }

        public double BleedingTime { get; set; }

        public double CoagulationTime { get; set; }

        public double MorphologyErythrocytes { get; set; }

        public double BloodSugar { get; set; }
    }
}
