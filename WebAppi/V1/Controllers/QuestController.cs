using Core.Entities;
using Core.Interfaces.Services;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// Quest api controller
    /// </summary>
    public class QuestController : BaseApiController<Quest>
    {
        public QuestController(IBaseService<Quest> baseService) : base(baseService)
        {
        }
    }
}
