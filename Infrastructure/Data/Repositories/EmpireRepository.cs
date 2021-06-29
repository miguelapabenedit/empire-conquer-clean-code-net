using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data.EntityFramework;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class EmpireRepository:EntityFrameworkRepository<Empire,DBEmpireContext>
    {
        public EmpireRepository(DBEmpireContext context):base(context)
        {
        }

        public async override Task<IQueryable<Empire>> GetAsync(Expression<Func<Empire, bool>> filter = null)
        {
            var empires = await GetHydratedEmpires().ToListAsync();
            return empires.AsQueryable();
        }

        #region private
        private IQueryable<Empire> GetHydratedEmpires()
        {
            return DBContext.Set<Empire>()
                .Include(e => e.User)
                .Include(e => e.Cities);
        }
        #endregion
    }
}
