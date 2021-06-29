using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Service.Helpers;
using System.Linq;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        public readonly IRepository<User> _userRepository;
        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public User ValidateUserCredential(string username, string password)
        {
            var user =  _userRepository.GetAsync(w => w.Email == username).Result.FirstOrDefault();
         
            if(user != null && user.Password == EncodeHelper.EncodePassword(password)) return user;

            return null;
        }
    }
}
