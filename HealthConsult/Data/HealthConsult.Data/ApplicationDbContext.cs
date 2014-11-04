namespace HealthConsult.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using HealthConsult.Data.Migrations;
    using HealthConsult.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext() : base("HealthConsultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<BloodExamination> BloodExaminations { get; set; }

        public IDbSet<Consultation> Consultations { get; set; }

        public IDbSet<Diagnosis> Diagnosis { get; set; }

        public IDbSet<Hospital> Hospitals { get; set; }

        public IDbSet<Schedule> Schedules { get; set; }

        public IDbSet<Specialist> Specialists { get; set; }

        public IDbSet<Speciality> Specialities { get; set; }

        public IDbSet<Urinalysis> Urinalysis { get; set; }

        public IDbSet<VisualExamination> VisualExaminations { get; set; }

        public IDbSet<Log> Logs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>()
                .HasRequired(c => c.Sender)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}