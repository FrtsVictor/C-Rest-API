using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManager.Api.Utils;
using UserManager.Api.ViewModels;
using UserManager.Core.Exceptions;
using UserManager.Services.DTO;
using UserManager.Services.Interfaces;

namespace UserManager.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService; 
        }
        
        [HttpPost]
        [Route("/api/v1/users/create")] //sempre versionar rotas
        public async Task<IActionResult> Create ([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);

                var userCreated = await _userService.Create(userDTO); // service só vai ler os dtos, por isso o mapper

                return Ok(new ResultViewModel{
                    Message = "User created sucessfully",
                    Sucess = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                 return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

    }
}