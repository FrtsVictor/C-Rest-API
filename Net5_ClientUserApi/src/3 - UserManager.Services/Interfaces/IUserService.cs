using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Services.DTO;

namespace UserManager.Services.Interfaces
{

    //comunicação entre api e servico é baseada sempre em dto, quem acessa o dominio é o serviço, depois retorna dtos, 
    //nunca usar classes com metodos para comunicação entre api e service
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Remove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> Get();
        Task<List<UserDTO>> SearchByName(string name);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<UserDTO> GetByEmail(string email);

    }
}