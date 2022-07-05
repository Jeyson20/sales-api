using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Dtos.Users;
using Sample.Application.Features.Users.Commands;
using System.Threading.Tasks;

namespace Sample.Presentation.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseAPIController
    {

        //[HttpGet]
        //[Route("listUsers")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        //[HttpGet]
        //[Route("getById{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await Mediator.Send(new GetCentroByIdQuery { Id = id }));
        //}

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Rol = request.Rol,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
            }));
        }

        //[HttpPut]
        //[Route("updateCategory")]
        //public async Task<IActionResult> Update(int id, CreateCategory command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        //[HttpDelete]
        //[Route("deleteCategory")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(command));
        //}
    }
}
