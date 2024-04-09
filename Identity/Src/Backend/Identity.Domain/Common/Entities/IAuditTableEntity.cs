using Microsoft.VisualBasic;

namespace Identity.Domain.Common.Entities;

public interface IAuditTableEntity:ISoftDeleteEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset? ModifiedTime { get; set; }
    
}