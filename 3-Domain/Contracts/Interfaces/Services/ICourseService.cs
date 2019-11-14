using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface ICourseService
    {
        Task<dynamic> Add(CourseRequest gradeRequest);

        IEnumerable<dynamic> GetAll();

        Task<dynamic> GetById(Guid id);

        void Update(CourseUpdateRequest gradeRequest, Guid gradeId);

        void Delete(Guid id);
    }
}
