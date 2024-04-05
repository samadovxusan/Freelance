namespace Identity.Domain.Common.Entities;

public interface IAuditTable
{
    public DateTimeOffset CreatedTime { get; set; }

    public DateTimeOffset? ModifiedTime { get; set; }
}