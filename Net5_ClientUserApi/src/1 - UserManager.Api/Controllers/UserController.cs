using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserManager.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpPost]
        [Route("/api/v1")] //sempre versionar rotas
        public async Task<IActionResult> Create ()
        {
            try
            {
                return Ok()       ;
            }
            // catch (DomainException ex)
            // {
            //      // TODO
            // }
            catch(Exception)
            {
                return StatusCode(500, "error");
            }
        }

    }
}