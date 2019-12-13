using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        void Add(T obj);

        void Delete(T obj);

        void Update(T obj);

        Task<T> FindById(Guid id);

        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAll();
    }
}