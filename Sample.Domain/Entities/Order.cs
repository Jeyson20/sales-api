using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
