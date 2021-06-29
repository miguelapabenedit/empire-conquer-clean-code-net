using Core.Entities;
using Infrastructure.Data.EntityFramework;

namespace Infrastructure.Data.Repositories
{
    public class GuildRepository : EntityFrameworkRepository<Guild,DBEmpireContext>
    {
        public GuildRepository(DBEmpireContext context) : base(context)
        {
        }
    }
}
