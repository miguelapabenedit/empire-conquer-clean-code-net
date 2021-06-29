using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddEntityFramework(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DBEmpireContext>(
                  options => options.UseSqlServer(configuration.GetConnectionString("EmpireConquer"))
                );

            service.AddScoped<IRepository<Game>, GameRepository>();
            service.AddScoped<IRepository<Map>, MapRepository>();
            service.AddScoped<IRepository<City>, CityRepository>();
            service.AddScoped<IRepository<Empire>, EmpireRepository>();
            service.AddScoped<IRepository<Heroe>, HeroeRepository>();
            service.AddScoped<IRepository<Quest>, QuestRepository>();
            service.AddScoped<IRepository<User>, UserRepository>();
            service.AddScoped<IRepository<Guild>, GuildRepository>();
        }
    }
}
