using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Entities;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly IUnitOfWork _uow;

        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public virtual void Add(T obj)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    _uow.Context.Set<T>().Add(obj);
                    _uow.Commit();
                    
                }
                catch (Exception ex)
                {
                    _uow.Rollback();
                    throw;
                }
            }
        }

        public virtual void Delete(T obj)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    _uow.Context.Set<T>().Remove(obj);
                    _uow.Commit();    
                }
                catch (Exception ex)
                {
                    _uow.Rollback();
                    throw;
                }
            }
        }

        public virtual async Task<T> FindById(Guid id)
        {
            return await _uow.Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _uow.Context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetByCondition(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _uow.Context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual void Update(T obj)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    _uow.Context.Entry(obj).State = EntityState.Modified;
                    _uow.Commit();    
                }
                catch (Exception ex)
                {
                    _uow.Rollback();
                    throw;
                }
            }
        }
    }
}