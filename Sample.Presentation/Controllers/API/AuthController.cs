using Microsoft.AspNetCore.Mvc;
using Sample.Application.Dtos.Users;
using Sample.Application.Features.Users.Commands;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Sample.Presentation.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseAPIController
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Login: generar token para acceder a controladores")]
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
