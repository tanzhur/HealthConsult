﻿namespace HealthConsult.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    using HealthConsult.Contracts;

    public class GenericRepository<T> : IGenericRepository<T> where T : class, IDeletableEntity
    {
        private readonly IApplicationDbContext context;
        private readonly IDbSet<T> set;

        public GenericRepository(IApplicationDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable().Where(s => !s.Deleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.set.AsQueryable();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.set.Attach(entity);
                this.set.Remove(entity);
            }
        }

        public void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.set.Attach(entity);
                this.set.Remove(entity);
            }
        }

        public void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}
