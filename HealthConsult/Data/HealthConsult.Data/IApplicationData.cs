namespace HealthConsult.Data
{
    using HealthConsult.Data.Models;
    using HealthConsult.Data.Repositories;

    public interface IApplicationData
    {
        IApplicationDbContext Context { get; }

        IGenericRepository<BloodExamination> BloodExaminations { get; }

        IGenericRepository<Consultation> Consultations { get; }

        IGenericRepository<Diagnosis> Diagnosis { get; }

        IGenericRepository<Hospital> Hospitals { get; }

        IGenericRepository<Schedule> Schedules { get; }

        IGenericRepository<Specialist> Specialists { get; }

        IGenericRepository<Speciality> Specialities { get; }

        IGenericRepository<Urinalysis> Urinalysis { get; }

        IGenericRepository<VisualExamination> VisualExaminations { get; }

        IGenericRepository<Log> Logs { get; }

        void SaveChanges();

        void Dispose();
    }
}
