using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Entities;
using Domain.Validations;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Application.Services
{
    public class StudentService : Notifiable, IStudentService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(
            IGradeRepository gradeRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
               
        public async Task<dynamic> Add(StudentRequest studentRequest)
        {
            if (studentRequest == null)
            {
                Error.Add("20000");
                return null;
            }
            
            var student = Student.Create(studentRequest.Name);
            //if (!user.IsValid)
            //{
            //    Error = user.Error;
            //    return null;
            //}
            //var course = await _courseRepository.FindById(Guid.Parse("B0DDB957-E4D4-482D-88AC-686ECE51CB52"));
            //var studentCourse = StudentCourse.Create(student, course);
            //student.RegistreStudent(studentCourse);
            _studentRepository.Add(student);

            var studentResponse = _mapper.Map<Student, StudentResponse>(student);

            return await Task.FromResult(studentResponse);
        }

        public void Delete(Guid id)
        {
            var entity = _studentRepository.FindById(id).Result;
            if (entity.Id == null)
                Error.Add("30000");

            _studentRepository.Delete(entity);
        }

        public IEnumerable<dynamic> GetAll()
        {
            return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResponse>>(_studentRepository.GetAll());
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
