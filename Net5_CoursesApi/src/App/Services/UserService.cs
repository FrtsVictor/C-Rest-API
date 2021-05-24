using System.Threading.Tasks;
using Infra.Entities;
using Infra.Repositories.Interfaces;

namespace App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
                
        public async Task<User> Criar(User user)
        {
            var userCreated = await _userRepository.Create(user);
            return userCreated;
        }
    }
}