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
    public class CourseService : Notifiable, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<dynamic> Add(CourseRequest courseRequest)
        {
            if (courseRequest == null)
            {
                Error.Add("20000");
                return null;
            }

            var course = Course.Create(courseRequest.Name);
            //if (!user.IsValid)
            //{
            //    Error = user.Error;
            //    return null;
            //}

            _courseRepository.Add(course);
            return await Task.FromResult(course);
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

        public void Update(CourseUpdateRequest courseUpdateRequest, Guid gradeId)
        {
            throw new NotImplementedException();
        }
    }
}
