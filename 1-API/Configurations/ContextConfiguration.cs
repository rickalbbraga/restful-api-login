using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configurations
{
    public static class ContextConfiguration
    {
        public static void AddContext(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Conn");
            services.AddDbContext<UserRegisterContext>(options => {
                options.UseSqlite(connectionString);
            });
        }
    }
}