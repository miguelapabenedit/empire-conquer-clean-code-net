using Core.Entities;
using Core.Interfaces.Services;

namespace WebApplication.V1.Controllers
{
    /// <summary>
    /// User api controller
    /// </summary>
    public class UserController : BaseApiController<User>
    {
        public UserController(IUserService baseService) : base(baseService)
        {
        }
    }
}
