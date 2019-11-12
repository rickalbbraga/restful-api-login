using Domain.Contracts.Interfaces.Repositories;
using Domain.Entities;
using Infra.Data.Interfaces;

namespace Infra.Data.Repositories
{
    public class UserRegisterRepository : BaseRepository<User>, IUserRegisterRepository
    {
        public UserRegisterRepository(IUnitOfWork uow) 
            : base(uow)
        {
        }
    }
}