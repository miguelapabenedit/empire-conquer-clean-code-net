using Core.Entities;
using Core.Interfaces.Services;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// Empire api controller
    /// </summary>
    public class EmpireController : BaseApiController<Empire>
    {
        public EmpireController(IBaseService<Empire> baseService) : base(baseService)
        {
        }
    }
}
