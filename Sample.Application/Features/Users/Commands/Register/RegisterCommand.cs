using MediatR;
using Sample.Application.Dtos.Users;
using Sample.Application.Interfaces;
using Sample.Application.Wrappers;
using Sample.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Users.Commands.Register
{
    public class RegisterCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Roles Rol { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<int>>
    {
        private readonly IUserService _userService;
        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Response<int>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterAsync(new UserRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Rol = request.Rol,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
            });
        }
    }
}

