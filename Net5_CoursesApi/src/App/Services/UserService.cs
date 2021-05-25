using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models.Users;
using Courses.Models.Users;
using Infra.Entities;
using Infra.Repositories.Interfaces;
using Net5_CoursesApi.Models.Users;

namespace App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
                
        public async Task<User> Create(User user)
        {
            var userCreated = await _userRepository.Create(user);
            return userCreated;
        }

        public async Task<UserViewModelOutput> Create(RegisterViewModelInput registerViewModelInput)
        {
            var user = 
            var userCreated = await _userRepository.Create();
            return new UserViewModelOutput();
        }

        public Task<UserViewModelOutput> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserViewModelOutput>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserViewModelOutput> GetByUsername(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserViewModelOutput>> SearchByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateUserViewModel> Update(UpdateUserViewModel updateUserViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}