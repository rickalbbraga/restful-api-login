using AutoMapper;
using Domain.Commands;
using Domain.Entities;
using Restful.Login.Domain.Contracts.Requests;
using Restful.Login.Domain.Contracts.Response;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Application.Mappers
{
    public class MappersConfiguration : Profile
    {
        public MappersConfiguration()
        {
            #region Model to Response
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

            CreateMap<Customer, CustomerResponse>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(d => d.Email, opt => opt.MapFrom(o => o.Email))
                .ForMember(d => d.Phone, opt => opt.MapFrom(o => o.Phone));
            #endregion

            #region Request to Command
            CreateMap<CustomerRequest, CustomerCreateCommand>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(d => d.Email, opt => opt.MapFrom(o => o.Email))
                .ForMember(d => d.Phone, opt => opt.MapFrom(o => o.Phone));
            #endregion
        }
    }
}
