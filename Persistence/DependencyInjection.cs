using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MedaitrDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("MediatrDatabase")));
            services.AddScoped<IMedaitrDBContext>(provider => provider.GetService<MedaitrDBContext>());

            return services;
        }
    }
}
