using System;
using System.Linq;
using Domain.Contracts.Interfaces.Repositories;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Restful.Login.Domain.Entities;

namespace Infra.Data.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Guid studentId, Guid courseId)
        {
            
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var course =  _unitOfWork.Context.Courses.FirstOrDefaultAsync(c => c.Id == courseId).Result;
                    var student = _unitOfWork.Context.Students.FirstOrDefaultAsync(s => s.Id == studentId).Result;
                    
                    var studentCourse = StudentCourse.Create(student, course);
                    student.RegistreStudent(studentCourse);

                    _unitOfWork.Context.Students.Update(student);
                    _unitOfWork.Commit();
                    
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    throw;
                }
            }
        }

        public void Delete(Guid studentId, Guid courseId)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var student = _unitOfWork.Context.Students.FirstOrDefault(s => s.Id == studentId);
                    var studentCourse = _unitOfWork.Context.StudentCourses
                        .FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);

                    student.StudentCourses.Remove(studentCourse);
                    _unitOfWork.Commit();
                    
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}