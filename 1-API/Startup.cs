using API.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restful.Login.API.Configurations;
using Restful.Login.Infra.CrossCutting.IoC;
using System;

namespace Restful.Login.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            SwaggerConfiguration.AddSwaggerService(services);
            ContextConfiguration.AddContext(services, Configuration);
            DependecyInjection.Injections(services, Configuration);
            RabbitConfiguration.Set(services, Configuration);
            JsonWebTokenConfiguration.Set(services, Configuration);
            AddMapperService.AddMapper(services);

            var assembly = AppDomain.CurrentDomain.Load("Restful.Login.Domain");
            services.AddMediatR(assembly);

            services.AddCors();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            MigrationsExecuteConfiguration.UpdateDatabase(app);

            SwaggerConfiguration.AddSwaggerApplicationBuilder(app);

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
