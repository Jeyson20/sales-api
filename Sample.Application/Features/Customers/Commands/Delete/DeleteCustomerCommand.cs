using MediatR;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces;
using Sample.Application.Wrappers;
using Sample.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
    {
        private readonly IGenericRepositoryAsync<Customer> _repositoryAsync;
        public DeleteCustomerCommandHandler(IGenericRepositoryAsync<Customer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryAsync.GetbyId(request.Id);
            if (customer == null)
            {
                throw new ApiException("cliente no encontrado");
            }
            else
            {
                await _repositoryAsync.Delete(customer.Id);
                return new Response<int>(customer.Id);
            }
        }
    }
}

