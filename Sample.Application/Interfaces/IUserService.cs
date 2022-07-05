using Sample.Application.Dtos.Users;
using Sample.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponse> AuthenticateAsync(AuthRequest request);
        Task<Response<int>> RegisterAsync(UserRequest request);
    }
}
