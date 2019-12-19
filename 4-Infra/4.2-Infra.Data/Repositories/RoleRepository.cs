using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Infra.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
