using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.DTOs;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login ([FromBody] LoginDTO loginDTO, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid || loginDTO == null)
            {
                return BadRequest(ModelState);
            }

              try
                {
                    var result = await service.FindByLogin(loginDTO);
                    if (result != null)
                    {
                        return  Ok (result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (ArgumentException e)
                {
                    
                    return StatusCode ((int)HttpStatusCode.InternalServerError, e.Message);
                }
                
            
        }
    }
}
