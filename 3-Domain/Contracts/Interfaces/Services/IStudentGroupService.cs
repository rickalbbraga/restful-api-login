using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface IStudentGroupService
    {
        Task<dynamic> Add(StudentGroupRequest studentGroupRequest);

        IEnumerable<dynamic> GetAll();

        Task<dynamic> GetById(Guid id);

        void Update(StudentGroupUpdateRequest tudentGroupUpdateRequest, Guid gradeId);

        void Delete(Guid id);
    }
}
