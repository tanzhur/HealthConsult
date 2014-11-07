namespace HealthConsult.Data
{
    using System;
    using System.Collections.Generic;

    using HealthConsult.Data.Models;
    using HealthConsult.Data.Repositories;
    using HealthConsult.Contracts;

    public class ApplicationData : IApplicationData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ApplicationData()
            : this(new ApplicationDbContext())
        {
        }

        public IGenericRepository<BloodExamination> BloodExaminations
        {
            get
            {
                return this.GetRepository<BloodExamination>();
            }
        }

        public IApplicationDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IGenericRepository<Consultation> Consultations
        {
            get
            {
                return this.GetRepository<Consultation>();
            }
        }

        public IGenericRepository<Diagnosis> Diagnosis
        {
            get
            {
                return this.GetRepository<Diagnosis>();
            }
        }

        public IGenericRepository<Hospital> Hospitals
        {
            get
            {
                return this.GetRepository<Hospital>();
            }
        }

        public IGenericRepository<Schedule> Schedules
        {
            get
            {
                return this.GetRepository<Schedule>();
            }
        }

        public IGenericRepository<Specialist> Specialists
        {
            get
            {
                return this.GetRepository<Specialist>();
            }
        }

        public IGenericRepository<Speciality> Specialities
        {
            get
            {
                return this.GetRepository<Speciality>();
            }
        }

        public IGenericRepository<Urinalysis> Urinalysis
        {
            get
            {
                return this.GetRepository<Urinalysis>();
            }
        }

        public IGenericRepository<VisualExamination> VisualExaminations
        {
            get
            {
                return this.GetRepository<VisualExamination>();
            }
        }

        public IGenericRepository<Log> Logs
        {
            get
            {
                return this.GetRepository<Log>();
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
