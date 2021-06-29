using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GameService : BaseService<Game>
    {
        public GameService(IUnitOfWork unitOfWork, IRepository<Game> gameRepository) : base(unitOfWork, gameRepository)
        {

        }
    }
}
