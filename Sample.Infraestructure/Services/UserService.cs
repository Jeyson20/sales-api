using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sample.Application.Dtos.Users;
using Sample.Application.Exceptions;
using Sample.Application.Interfaces;
using Sample.Application.Wrappers;
using Sample.Domain.Entities;
using Sample.Domain.Enums;
using Sample.Domain.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infraestructure.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IGenericRepositoryAsync<User> _repositoryAsync;
        public UserService(IConfiguration config, IGenericRepositoryAsync<User> repositoryAsync)
        {
            _config = config;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<AuthResponse> AuthenticateAsync(AuthRequest request)
        {
            var user = await _repositoryAsync.Find(x => x.Email == request.Email && x.Password == Encryption.Encrypt(request.Password));
            if (user == null)
                throw new ApiException("Usuario o Contraseña incorrecta");
            if(user.State == "Inactive")
                throw new ApiException("Usuario inactivo, comuniquese con el administrador");

            AuthResponse response = new()
            {
                Token = GenerateToken(user),
                UserData = new UserResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Rol = user.Rol,
                    State = user.State,
                },
                RefreshToken = "Jeyson" //Arreglar
            };

            return response;
        }
        public async Task<Response<int>> RegisterAsync(UserRequest request)
        {
            var email = await _repositoryAsync.Find(x => x.Email == request.Email);
            if (email != null)
                throw new ApiException("Ya este email esta en uso");

            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = Encryption.Encrypt(request.Password),
                Email = request.Email,
                Rol = request.Rol.ToString(),
                State = State.Inactive.ToString(),
            };

            var result = await _repositoryAsync.Add(user);
            if (result != null)
                return new Response<int>(result.Id, message: $"Usuario registrado exitosamente. {request.Email}");
            else
                throw new ApiException("Ocurrio un error al crear Usuario");
        }


        #region Private Methods

        private string GenerateToken(User request)
        {
            var symetricSecuritykey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_config["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(symetricSecuritykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("name", request.FirstName +" "+ request.LastName),
                new Claim(JwtRegisteredClaimNames.Email, request.Email),
                new Claim("role" ,request.Rol),
            };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        #endregion
    }
}
