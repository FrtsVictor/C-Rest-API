
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UserManager.Core.Exceptions;
using UserManager.Domain.Entities;
using UserManager.Infra.Interfaces;
using UserManager.Services.DTO;
using UserManager.Services.Interfaces;

namespace UserManager.Services.Services
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExistis = await _userRepository.GetByEmail(userDTO.Email);

            if(userExistis !=null)
            {
                throw new DomainException("Email already registred");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);            
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

         public async Task<List<UserDTO>> SearchByName(string name){
            var allUsers = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<List<UserDTO>> Get(){
            var allUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExistis = await _userRepository.Get(userDTO.Id);

            if(userExistis == null)
            {
                throw new DomainException("User not found");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email){
            var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email){
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }


    }

}