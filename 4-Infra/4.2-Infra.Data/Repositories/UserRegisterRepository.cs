using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Entities;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserRegisterRepository : BaseRepository<User>, IUserRegisterRepository
    {
        public UserRegisterRepository(IUnitOfWork uow) 
            : base(uow)
        {
        }

        public override async Task<IEnumerable<User>> GetByCondition(Expression<Func<User, bool>> predicate)
        {
            return await _uow.Context.Users.Include(u => u.Role).Where(predicate).ToListAsync();
        }
    }
}