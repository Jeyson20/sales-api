using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Category: AuditableBaseEntity
    {
        public string Categoryname { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
