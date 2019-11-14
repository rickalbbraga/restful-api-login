using Domain.Entities;
using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;

namespace Restful.Login.Infra.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
