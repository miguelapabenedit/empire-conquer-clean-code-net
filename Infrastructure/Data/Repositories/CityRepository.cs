using Core.Entities;
using Infrastructure.Data.EntityFramework;

namespace Infrastructure.Data.Repositories
{
    public class CityRepository:EntityFrameworkRepository<City,DBEmpireContext>
    {
        public CityRepository(DBEmpireContext context):base(context)
        {
        }
    }
}
