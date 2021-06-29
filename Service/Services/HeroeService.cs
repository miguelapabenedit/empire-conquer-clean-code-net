using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Service.Services
{
    public class HeroeService : BaseService<Heroe>
    {
        public HeroeService(IUnitOfWork unitOfWork, IRepository<Heroe> heroeRepository) : base(unitOfWork, heroeRepository)
        {
        }
    }
}
