using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Service.Services
{
    public class QuestService : BaseService<Quest>
    {
        public QuestService(IUnitOfWork unitOfWork, IRepository<Quest> questRepository) : base(unitOfWork, questRepository)
        {
        }
    }
}
