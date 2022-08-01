using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Sample.Application.Exceptions;
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
    }

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
            var category = await _repositoryAsync.Find(x => x.Categoryname == request.CategoryName);
            if (category != null)
            {
                throw new ApiException("Ya existe una categoria con este nombre");
            }
            var nuevoRegistro = _mapper.Map<Category>(request);
            var data = await _repositoryAsync.Add(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}

