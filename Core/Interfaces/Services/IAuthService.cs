using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IAuthService
    {
        User ValidateUserCredential(string username, string password);
    }
}
