using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Restful.Login.Application.Mappers;

namespace Restful.Login.API.Configurations
{
    public static class AddMapperService
    {
        public static void AddMapper(IServiceCollection services)
        {
            var mappersConfigurations = new MapperConfiguration(config => {
                config.AddProfile(new MappersConfiguration());
            });

            IMapper mapper = mappersConfigurations.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
