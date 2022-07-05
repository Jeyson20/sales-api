using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
