using Infra.Entities;
using Net5_CoursesApi.Models.Users;

namespace App.Token
{
    public interface ITokenGenerator
    {
         string GenerateToken(UserViewModelOutput user);
         UserViewModelOutput createTesteUser();
    }
}