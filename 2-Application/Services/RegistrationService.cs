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

        public RegistrationService(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<dynamic> Add(RegistrationRequest registrationRequest)
        {
            if (registrationRequest == null)
            {
                Error.Add("20000");
                return null;
            }

            var course = await _courseRepository.FindById(registrationRequest.CoursetId);
            var student = await _studentRepository.FindById(registrationRequest.StudentId);
            var studentCourse = StudentCourse.Create(student, course);            
            student.RegistreStudent(studentCourse);       
            
            _studentRepository.Update(student);

            return await Task.FromResult(true);
        }
    }
}
