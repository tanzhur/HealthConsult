namespace HealthConsult.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using HealthConsult.Contracts;


    public interface IGenericRepository<T> where T : class, IDeletableEntity
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}
