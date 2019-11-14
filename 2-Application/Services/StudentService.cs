using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Entities;
using Domain.Validations;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;

namespace Restful.Login.Application.Services
{
    public class StudentService : Notifiable, IStudentService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(
            IGradeRepository gradeRepository,
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
               
        public async Task<dynamic> Add(StudentRequest studentRequest)
        {
            if (studentRequest == null)
            {
                Error.Add("20000");
                return null;
            }

            var grade = await _gradeRepository.FindById(studentRequest.GradeId);
            var student = Student.Create(studentRequest.Name, grade);
            //if (!user.IsValid)
            //{
            //    Error = user.Error;
            //    return null;
            //}

            _studentRepository.Add(student);

            var studentResponse = _mapper.Map<Student, StudentResponse>(student);

            return await Task.FromResult(studentResponse);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<dynamic> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentUpdateRequest studentUpdateRequest, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
