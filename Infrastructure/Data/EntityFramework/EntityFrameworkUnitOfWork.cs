using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityFramework
{
    public class EntityFrameworkUnitOfWork<TContext> : IUnitOfWork where TContext:DbContext
    {
        private TContext _context { get; set; }
        public EntityFrameworkUnitOfWork(TContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
