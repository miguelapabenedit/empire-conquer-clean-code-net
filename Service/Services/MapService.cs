using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Service.Services
{
    public class MapService:BaseService<Map>
    {
        public MapService(IUnitOfWork unitOfWork, IRepository<Map> mapRepository):base(unitOfWork,mapRepository)
        {
        }
    }
}
