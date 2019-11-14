using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Infra.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
