using AutoMapper;
using Domain.Entities;
using Restful.Login.Domain.Contracts.Response;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Application.Mappers
{
    public class MappersConfiguration : Profile
    {
        public MappersConfiguration()
        {
            CreateMap<Student, StudentResponse>()
               .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
               .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name));               

            CreateMap<StudentGroup, StudentGroupResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Course, opt => opt.MapFrom(o => o.Course));

            CreateMap<Course, CourseResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name));

        }
    }
}
