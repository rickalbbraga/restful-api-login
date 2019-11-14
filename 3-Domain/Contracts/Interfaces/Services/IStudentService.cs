using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface IStudentService
    {
        Task<dynamic> Add(StudentRequest studentRequest);

        IEnumerable<dynamic> GetAll();

        Task<dynamic> GetById(Guid id);

        void Update(StudentUpdateRequest studentUpdateRequest, Guid userId);

        void Delete(Guid id);
    }
}
