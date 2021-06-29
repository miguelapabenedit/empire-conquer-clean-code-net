using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Infrastructure.Data.EntityFramework;
using Infrastructure.Extensions;
using Service.Services;

namespace Service.Extensions
{
    public static class ServicesCollectionExtension
    {
        // <summary>
        /// Add all the Empire Conquer's dependencies to the collection.
        /// </summary>
        /// <param name="service">IServiceCollection.</param>
        /// <param name="configuration">IConfiguration.</param>
        public static void AddEmpireConquerToModule(this IServiceCollection service, IConfiguration configuration) {

            service.AddEntityFramework(configuration);
            service.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork<DBEmpireContext>>();

            service.AddScoped<IBaseService<City>, CityService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IBaseService<Empire>, EmpireService>();
            service.AddScoped<IBaseService<Heroe>, HeroeService>();
            service.AddScoped<IBaseService<Map>, MapService>();
            service.AddScoped<IBaseService<Quest>, QuestService>();
            service.AddScoped<IGuildService, GuildService>();
            service.AddScoped<IBaseService<Game>, GameService>();

        }        
    }
}
