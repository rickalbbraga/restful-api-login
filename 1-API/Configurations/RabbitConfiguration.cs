using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restful.Login.Domain.Contracts.Notifications;
using Restful.Login.Domain.Utils;

namespace API.Configurations
{
    public static class RabbitConfiguration
    {
        public static void Set(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqConfiguration>(configuration.GetSection("RabbitConfig"));
            services.AddSingleton<IRabbitMqService, RabbitMqService>();
        }
    }
}