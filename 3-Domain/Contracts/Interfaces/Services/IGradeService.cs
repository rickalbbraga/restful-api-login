using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface IGradeService
    {
        Task<dynamic> Add(GradeRequest gradeRequest);

        IEnumerable<dynamic> GetAll();

        Task<dynamic> GetById(Guid id);

        void Update(GradeUpdateRequest gradeRequest, Guid gradeId);

        void Delete(Guid id);
    }
}
