using Core.Entities;
using Core.Interfaces.Services;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// Game api controller
    /// </summary>
    public class GameController : BaseApiController<Game>
    {
        public GameController(IBaseService<Game> baseService) : base(baseService)
        {
        }
    }
}
