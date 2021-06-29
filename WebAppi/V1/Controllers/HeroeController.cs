using Core.Entities;
using Core.Interfaces.Services;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// Heroe api controller
    /// </summary>
    public class HeroeController : BaseApiController<Heroe>
    {
        public HeroeController(IBaseService<Heroe> baseService) : base(baseService)
        {
        }
    }
}
