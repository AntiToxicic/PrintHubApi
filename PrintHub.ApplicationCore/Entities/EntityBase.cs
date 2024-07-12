namespace PrintHub.Core.Entities;

public class EntityBase
{
    public uint Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
}