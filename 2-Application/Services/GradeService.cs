using Domain.Contracts.Interfaces.Repositories;
using Domain.Entities;
using Domain.Validations;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Domain.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restful.Login.Application.Services
{
    public class GradeService : Notifiable, IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<dynamic> Add(GradeRequest gradeRequest)
        {
            if (gradeRequest == null)
            {
                Error.Add("20000");
                return null;
            }

            var grade = Grade.Create(gradeRequest.Name);
            //if (!user.IsValid)
            //{
            //    Error = user.Error;
            //    return null;
            //}

            _gradeRepository.Add(grade);
            return await Task.FromResult(grade);
        }

        public void Delete(Guid id)
        {
            var entity = _gradeRepository.FindById(id).Result;
            if (entity.Id == null)
                Error.Add("30000");

            _gradeRepository.Delete(entity);
        }

        public IEnumerable<dynamic> GetAll()
        {
            return _gradeRepository.GetAll().Result;
        }

        public async Task<dynamic> GetById(Guid id)
        {
            return await _gradeRepository.FindById(id);
        }

        public void Update(GradeUpdateRequest gradeRequest, Guid gradeId)
        {
            var entityRegistered = _gradeRepository.FindById(gradeId).Result;
            entityRegistered.Update(gradeRequest);

            //if (!entityRegistered.IsValid)
            //    Error = entityRegistered.Error;

            _gradeRepository.Update(entityRegistered);
        }
    }
}
