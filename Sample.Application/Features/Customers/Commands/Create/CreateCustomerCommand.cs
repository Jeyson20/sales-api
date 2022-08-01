using AutoMapper;
using MediatR;
using Sample.Application.Interfaces;
using Sample.Application.Wrappers;
using Sample.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<Customer> _repositoryAsync;
        public CreateCustomerCommandHandler(IMapper mapper, IGenericRepositoryAsync<Customer> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = _mapper.Map<Customer>(request);
            var data = await _repositoryAsync.Add(newCustomer);
            return new Response<int>(data.Id);
        }
    }
}

