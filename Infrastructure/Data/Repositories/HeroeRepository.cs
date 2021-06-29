using Core.Entities;
using Infrastructure.Data.EntityFramework;

namespace Infrastructure.Data.Repositories
{
    public class HeroeRepository:EntityFrameworkRepository<Heroe,DBEmpireContext>
    {
        public HeroeRepository(DBEmpireContext context):base(context)
        {
        }
    }
}
