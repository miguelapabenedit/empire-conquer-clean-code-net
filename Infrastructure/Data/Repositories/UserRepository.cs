using Core.Entities;
using Infrastructure.Data.EntityFramework;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository:EntityFrameworkRepository<User,DBEmpireContext>
    {
        public UserRepository(DBEmpireContext context):base(context)
        {
        }
    }
}
