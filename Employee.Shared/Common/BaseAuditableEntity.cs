using Employee.Shared.Enums;

namespace Employee.Shared.Common
{
    public abstract class BaseAuditableEntity
    {
        /// <summary>
        /// Created
        /// </summary>
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public string? CreatedBy { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public EntityStatus Status { get; set; }
    }
}
