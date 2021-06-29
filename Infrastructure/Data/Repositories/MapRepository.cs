using Core.Entities;
using Infrastructure.Data.EntityFramework;

namespace Infrastructure.Data.Repositories
{
    public class MapRepository : EntityFrameworkRepository<Map, DBEmpireContext>
    {
        public MapRepository(DBEmpireContext context) : base(context)
        {
        }
    }
}
