using Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
         UserRegisterContext Context { get; }

         IDbContextTransaction BeginTransaction();

         void Commit();

         void Rollback();
    }
}