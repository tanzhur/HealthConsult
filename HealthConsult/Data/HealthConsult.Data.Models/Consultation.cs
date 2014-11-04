namespace HealthConsult.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HealthConsult.Data.Models.Enumerations;

    public class Consultation
    {
        public Consultation()
        {
            this.BloodExaminations = new HashSet<BloodExamination>(); 
            this.Urinalysis = new HashSet<Urinalysis>(); 
            this.VisualExaminations = new HashSet<VisualExamination>(); 
        }

        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }

        public Specialist Sender { get; set; }

        public int ConsultantId { get; set; }

        public Specialist Consultant { get; set; }

        [Required]
        public string PatientInitials { get; set; }

        [Required]
        public int PatientAge { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string PreliminaryDiagnosisCode { get; set; }

        public virtual Diagnosis PreliminaryDiagnosis { get; set; }

        [Required]
        public string Anamnesis { get; set; }

        public virtual ICollection<BloodExamination> BloodExaminations { get; set; }

        public virtual ICollection<Urinalysis> Urinalysis { get; set; }

        public virtual ICollection<VisualExamination> VisualExaminations { get; set; }

        public string FinalDiagnosisCode { get; set; }

        public virtual Diagnosis FinalDiagnosis { get; set; }

        public string Conclusion { get; set; }

        [Required]
        public ConsultationType Type { get; set; }

        [Required]
        public ConsultationStage Stage { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; }
    }
}