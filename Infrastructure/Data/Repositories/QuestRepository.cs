using Core.Entities;
using Infrastructure.Data.EntityFramework;

namespace Infrastructure.Data.Repositories
{
    public class QuestRepository:EntityFrameworkRepository<Quest,DBEmpireContext>
    {
        public QuestRepository(DBEmpireContext context):base(context)
        {

        }
    }
}
