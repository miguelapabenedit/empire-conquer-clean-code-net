using Core.Entities;
using Infrastructure.Data.EntityFramework;

namespace Infrastructure.Data.Repositories
{
    public class GameRepository : EntityFrameworkRepository<Game, DBEmpireContext>
    {
        public GameRepository(DBEmpireContext context) : base(context)
        {
        }
    }
}
