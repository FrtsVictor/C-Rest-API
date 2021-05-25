using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models.Users;
using Courses.Models.Users;
using Infra.Entities;
using Net5_CoursesApi.Models.Users;

namespace App.Services
{
    public interface IUserService
    {
        Task<UserViewModelOutput> Create(RegisterViewModelInput registerViewModelInput);
        Task<UpdateUserViewModel> Update(UpdateUserViewModel updateUserViewModel);
        Task Remove(long id);
        Task<UserViewModelOutput> Get(long id);
        Task<List<UserViewModelOutput>> Get();
        Task<List<UserViewModelOutput>> SearchByEmail(string email);
        Task<UserViewModelOutput> GetByUsername(string email);
    }
}