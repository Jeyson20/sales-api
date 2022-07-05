using Sample.Domain.Common;
using Sample.Domain.Enums;

namespace Sample.Domain.Entities
{
    public class User: AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string State { get; set; }
    }
}
