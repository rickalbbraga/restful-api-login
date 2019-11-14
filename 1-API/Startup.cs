using API.Configurations;
using Application.Services;
using AutoMapper;
using Domain.Contracts.Interfaces.Repositories;
using Domain.Contracts.Interfaces.Services;
using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Restful.Login.Application.Mappers;
using Restful.Login.Application.Services;
using Restful.Login.Domain.Contracts.Interfaces.Repositories;
using Restful.Login.Domain.Contracts.Interfaces.Services;
using Restful.Login.Infra.Data.Repositories;

namespace Restful.Login.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SwaggerConfiguration.AddSwaggerService(services);
            ContextConfiguration.AddContext(services, Configuration);

            services.AddScoped<IUserRegisterService, UserRegisterService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            var mappersConfigurations = new MapperConfiguration(config => {
                config.AddProfile(new MappersConfiguration());
            });

            IMapper mapper = mappersConfigurations.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
                //.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SwaggerConfiguration.AddSwaggerApplicationBuilder(app);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
