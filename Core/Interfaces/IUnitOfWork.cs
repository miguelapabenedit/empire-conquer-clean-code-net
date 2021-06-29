using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        public void Save();
        public Task SaveAsync();
    }
}
