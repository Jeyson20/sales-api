using System;

namespace Sample.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
