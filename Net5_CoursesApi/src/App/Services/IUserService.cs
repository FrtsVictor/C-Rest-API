using System.Threading.Tasks;
using Infra.Entities;

namespace App.Services
{
    public interface IUserService
    {
         Task<User> Criar(User user);
    }
}