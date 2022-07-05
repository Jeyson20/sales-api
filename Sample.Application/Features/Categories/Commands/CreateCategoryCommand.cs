using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Sample.Application.Interfaces;
using Sample.Application.Wrappers;
using Sample.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Response<int>>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }

        public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Response<int>>
        {
            private readonly IGenericRepositoryAsync<Category> _repositoryAsync;
            private readonly IMapper _mapper;
            public CreateCategoryHandler(IGenericRepositoryAsync<Category> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var nuevoRegistro = _mapper.Map<Category>(request);
                var data = await _repositoryAsync.Add(nuevoRegistro);
                return new Response<int>(data.Id, message: "La categoria ha sido creada");
            }
        }
    }
}
