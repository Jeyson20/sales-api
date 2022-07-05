using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sample.Application.Dtos.Users
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public UserResponse UserData{ get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }

    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Rol { get; set; }
        public string State { get; set; }
    }
}

