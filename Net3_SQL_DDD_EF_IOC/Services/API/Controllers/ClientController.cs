using System;
using System.Collections;
using System.Collections.Generic;
using Application.API.Application.Dtos;
using Application.API.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Services.API.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientServiceApplication _clientApplicationService;
        
        public ClientController(IClientServiceApplication ApplicationService)
        {
            _clientApplicationService = ApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_clientApplicationService.GetAll());
        }

        [HttpPost]
        public ActionResult Post(
            [FromBody] ClientDto clientDto
            )
        {
            try
            {
                if(clientDto == null)
                return NotFound();
                
                _clientApplicationService.Add(clientDto);
                return Ok("Client registred successfully!");
            }

            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        [HttpPut]
        public ActionResult Put(
            [FromBody] ClientDto clientDto
            )
        {
            try
            {
                if(clientDto == null)
                return NotFound();
                
                _clientApplicationService.Update(clientDto);
                return Ok("Client updated successfully!");
            }

            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete(
            [FromBody] ClientDto clientDto
            )
        {
            try
            {
                if(clientDto == null)
                return NotFound();
                
                _clientApplicationService.Remove(clientDto);
                return Ok("Client removed successfully!");
            }

            catch (Exception ex)
            {
                
                throw ex;
            
        }

       }   }
}