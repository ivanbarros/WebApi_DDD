using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        [HttpPost]
        public async Task<object> Login ([FromBody] UserEntity userEntity, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid || userEntity == null)
            {
                return BadRequest(ModelState);
            }

              try
                {
                    var result = await service.FindByLogin(userEntity);
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
