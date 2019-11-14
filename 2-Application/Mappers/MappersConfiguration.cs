using AutoMapper;
using Domain.Entities;
using Restful.Login.Domain.Contracts.Response;

namespace Restful.Login.Application.Mappers
{
    public class MappersConfiguration : Profile
    {
        public MappersConfiguration()
        {
            CreateMap<Student, StudentResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Grade, opt => opt.MapFrom(o => o.Grade));

            CreateMap<Grade, GradeResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name));

        }
    }
}
