using Core.Entities;
using Core.Interfaces.Services;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// Map api controller
    /// </summary>
    public class MapController : BaseApiController<Map>
    {
        public MapController(IBaseService<Map> baseService) : base(baseService)
        {
        }
    }
}
