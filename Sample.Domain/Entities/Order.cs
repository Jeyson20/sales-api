using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public Customer Customer { get; set; }
    }
}
