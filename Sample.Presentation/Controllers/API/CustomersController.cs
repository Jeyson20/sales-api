using Microsoft.AspNetCore.Mvc;
using Sample.Application.Features.Customers.Commands.Create;
using Sample.Application.Features.Customers.Commands.Delete;
using Sample.Application.Features.Customers.Commands.Update;
using System.Threading.Tasks;

namespace Sample.Presentation.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await Mediator.Send());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await Mediator.Send());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerCommand { Id = id }));
        }
    }
}
