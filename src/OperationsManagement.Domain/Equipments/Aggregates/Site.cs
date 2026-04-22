using OperationsManagement.Domain._Shared;

namespace OperationsManagement.Domain.Equipments.Aggregates;

public sealed class Site : AggregateRoot
{
    public string Name { get; private set; } = string.Empty;

    // Sites track their Areas
    private readonly List<Guid> _areaIds = [];
    public IReadOnlyCollection<Guid> AreaIds => _areaIds.AsReadOnly();
}
