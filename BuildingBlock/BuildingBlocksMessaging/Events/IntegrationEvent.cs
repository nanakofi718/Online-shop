namespace BuildingBlocksMessaging.Events;

public record IntegrationEvent
{
    public Guid Id { get; init; }

    public DateTime OccuredOn => DateTime.UtcNow;

    public string EventType => GetType().AssemblyQualifiedName;

}
