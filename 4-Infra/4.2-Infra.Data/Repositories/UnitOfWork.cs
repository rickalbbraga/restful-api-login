using Infra.Data.Context;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserRegisterContext Context { get; }

        public UnitOfWork(UserRegisterContext context)
        {
            Context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransactionAsync().Result;
        }

        public void Commit()
        {
            Context.SaveChangesAsync().Wait();
            Context.Database.CurrentTransaction.CommitAsync().Wait();
        }

        public void Rollback()
        {
            Context.Database.CurrentTransaction.RollbackAsync().Wait();
        }
    }
}