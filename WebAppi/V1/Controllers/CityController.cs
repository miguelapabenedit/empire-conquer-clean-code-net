using Core.Entities;
using Core.Interfaces.Services;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// City api controller
    /// </summary>
    public class CityController : BaseApiController<City>
    {
        public CityController(IBaseService<City> baseService) : base(baseService)
        {
        }
    }
}
