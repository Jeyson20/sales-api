using MediatR;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces;
using Sample.Application.Wrappers;
using Sample.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
    {
        private readonly IGenericRepositoryAsync<Customer> _repositoryAsync;
        public UpdateCustomerCommandHandler(IGenericRepositoryAsync<Customer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryAsync.GetbyId(request.Id);
            if (customer == null)
            {
                throw new ApiException("cliente no encontrado");
            }
            else
            {
                customer.FirstName = request.FirstName;
                customer.LastName = request.LastName;
                customer.DocumentNumber = request.DocumentNumber;
                customer.Address = request.Address;
                customer.CityId = request.CityId;
                customer.Email = request.Email;
                customer.PhoneNumber = request.PhoneNumber;

                await _repositoryAsync.Update(customer);
                return new Response<int>(customer.Id);
            }
        }
    }
}
