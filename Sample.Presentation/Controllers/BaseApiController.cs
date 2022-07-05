using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Presentation.Controllers
{
    [ApiController]
    //es para poder consumir el controlador dependiendo la version
    // Nos sirve para que heredemos de el y usemos el Mediator
    [Route("api/v{version:ApiVersion}/[controller]")]
    public abstract class BaseAPIController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}