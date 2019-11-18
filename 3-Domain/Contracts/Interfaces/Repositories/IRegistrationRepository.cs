using System;

namespace Domain.Contracts.Interfaces.Repositories
{
    public interface IRegistrationRepository
    {
        void Add(Guid studentId, Guid courseId);
        
        void Delete(Guid studentId, Guid courseId);
    }
}