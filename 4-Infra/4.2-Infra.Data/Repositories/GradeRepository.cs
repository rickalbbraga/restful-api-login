using Domain.Contracts.Interfaces.Repositories;
using Domain.Entities;
using Infra.Data.Interfaces;
using Infra.Data.Repositories;

namespace Restful.Login.Infra.Data.Repositories
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
