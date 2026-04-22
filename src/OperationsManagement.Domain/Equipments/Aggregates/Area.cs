namespace OperationsManagement.Domain.Equipments.Aggregates;

public sealed class Area : AggregateRoot
{
    public Guid SiteId { get; private set; }
    public string Name { get; private set; }
}
