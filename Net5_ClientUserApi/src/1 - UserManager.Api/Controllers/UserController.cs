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

        [HttpPut]
        [Route("api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userUpdated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User updated sucessfully",
                    Sucess = true,
                    Data = userUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpDelete]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "User removed sucessfully",
                    Sucess = true,
                    Data = null
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

        [HttpGet]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> GetAction(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if(user == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "User not found",
                        Sucess = true,
                        Data = null
                    });
                }

                

            }
        }

    }
}