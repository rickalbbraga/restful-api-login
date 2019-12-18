using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Validations;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Application.Services
{
    public class StudentGroupService : Notifiable, IStudentGroupService
    {
        private readonly IStudentGroupRepository _studentGroupRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public StudentGroupService(
            IStudentGroupRepository studentGroupRepository,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _studentGroupRepository = studentGroupRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<dynamic> Add(StudentGroupRequest studentGroupRequest)
        {
            if (studentGroupRequest == null)
            {
                Error.Add("20000");
                return null;
            }

            var course = await _courseRepository.FindById(studentGroupRequest.CourseId);
            var studentGroup = StudentGroup.Create(studentGroupRequest.Name, course);

            _studentGroupRepository.Add(studentGroup);

            var studentResponse = _mapper.Map<StudentGroup, StudentGroupResponse>(studentGroup);

            return await Task.FromResult(studentResponse);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentGroupUpdateRequest tudentGroupUpdateRequest, Guid gradeId)
        {
            throw new NotImplementedException();
        }
    }
}
