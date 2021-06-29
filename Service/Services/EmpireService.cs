using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Service.Services
{
    public class EmpireService:BaseService<Empire>
    {
        public EmpireService(IUnitOfWork unitOfWork, IRepository<Empire> empireRepository):base(unitOfWork,empireRepository)
        {
        }
    }
}
