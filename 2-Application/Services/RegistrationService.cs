using Domain.Contracts.Interfaces.Repositories;
using Domain.Validations;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Application.Services
{
    public class RegistrationService : Notifiable, IRegistrationService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IRegistrationRepository registrationRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _registrationRepository = registrationRepository;
        }

        public async Task<dynamic> Add(RegistrationRequest registrationRequest)
        {
            if (registrationRequest.StudentId == Guid.Empty)
            {
                Error.Add("StudentId is required");
                return null;
            }

            if (registrationRequest.CoursetId == Guid.Empty)
            {
                Error.Add("CourseId is required");
                return null;
            }

            _registrationRepository.Add(registrationRequest.StudentId, registrationRequest.CoursetId);            
            
            return await Task.FromResult(true);
        }

        public void Delete(Guid studentId, Guid courseId)
        {
            if (studentId == Guid.Empty)
            {
                Error.Add("StudentId is required");
                return;
            }

            if (courseId == Guid.Empty)
            {
                Error.Add("CourseId is required");
                return;
            }
            
            _registrationRepository.Delete(studentId, courseId);
        }
    }
}
