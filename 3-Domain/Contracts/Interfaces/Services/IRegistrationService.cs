using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Threading.Tasks;

namespace Restful.Login.Domain.Contracts.Interfaces.Services
{
    public interface IRegistrationService
    {
        Task<dynamic> Add(RegistrationRequest registrationRequest);

        void Delete(Guid studentId, Guid courseId);
    }
}
