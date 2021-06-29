using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Service.Services
{
    public class CityService : BaseService<City>
    {
        public CityService(IUnitOfWork unitOfWork, IRepository<City> cityRepository):base(unitOfWork,cityRepository)
        {
        }
    }
}
