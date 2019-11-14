using Application.Services;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Contracts.Interfaces.Services;
using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Restful.Login.Application.Services;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Infra.Data.Repositories;

namespace Restful.Login.Infra.CrossCutting.IoC
{
    public static class DependecyInjection
    {
        public static void Injections(IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
        } 

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentGroupRepository, StudentGroupRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserRegisterService, UserRegisterService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IStudentGroupService, StudentGroupService>();
        }
    }
}
