using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Service.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService :BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> userRepository) : base(unitOfWork, userRepository)
        {
        }

        public override Task<User> CreateAsync(User value, string userName)
        {
            value.Password = EncodeHelper.EncodePassword(value.Password);
            return base.CreateAsync(value, userName);
        }
    }
}
