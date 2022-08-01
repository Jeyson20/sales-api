using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Customer : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
