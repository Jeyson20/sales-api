using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Features.Categories.Commands;
using System.Threading.Tasks;

namespace Sample.Presentation.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseAPIController
    {
        //[HttpGet]
        //[Route("listCategories")]
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

        [HttpPost, Authorize]
        [Route("createCategory")]
        public async Task<IActionResult> Create([FromBody]CreateCategoryCommand command)
        {
            return Ok( await Mediator.Send(command));
        }

        [HttpPut]
        [Route("updateCategory")]
        public async Task<IActionResult> Update(int? id, CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpDelete]
        //[Route("deleteCategory")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(command));
        //}
    }
}
