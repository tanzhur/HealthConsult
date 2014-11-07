namespace HealthConsult.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using HealthConsult.Data.Models;

    public interface IApplicationDbContext
    {
        IDbSet<BloodExamination> BloodExaminations { get; set; }

        IDbSet<Consultation> Consultations { get; set; }

        IDbSet<Diagnosis> Diagnosis { get; set; }

        IDbSet<Hospital> Hospitals { get; set; }

        IDbSet<Schedule> Schedules { get; set; }

        IDbSet<Specialist> Specialists { get; set; }

        IDbSet<Speciality> Specialities { get; set; }

        IDbSet<Urinalysis> Urinalysis { get; set; }

        IDbSet<VisualExamination> VisualExaminations { get; set; }

        IDbSet<Log> Logs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        void Dispose();
    }
}