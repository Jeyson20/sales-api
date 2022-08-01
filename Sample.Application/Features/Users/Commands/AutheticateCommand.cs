using MediatR;
using Sample.Application.Dtos.Users;
using Sample.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Features.Users.Commands
{
    public class AutheticateCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class AutheticateCommandHandler : IRequestHandler<AutheticateCommand, AuthResponse>
    {
        private readonly IUserService _userService;
        public AutheticateCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AuthResponse> Handle(AutheticateCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AuthenticateAsync(new AuthRequest
            {
                Email = request.Email,
                Password = request.Password,
            });
        }
    }
}
