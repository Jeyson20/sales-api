using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Dtos.Users;
using Sample.Application.Features.Users.Commands;
using System.Threading.Tasks;

namespace Sample.Presentation.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseAPIController
    {

        [HttpPost("login")]
        public async Task<IActionResult> AutheticationAsync(AuthRequest request)
        {

            return Ok(await Mediator.Send(new AutheticateCommand
            {
                Email = request.Email,
                Password = request.Password,
            }));
        }
    }
}
