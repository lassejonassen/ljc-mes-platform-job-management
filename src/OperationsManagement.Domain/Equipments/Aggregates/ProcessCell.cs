using OperationsManagement.Domain.Equipments.Entities;

namespace OperationsManagement.Domain.Equipments.Aggregates;

public sealed class ProcessCell : AggregateRoot
{
    public Guid Id { get; private set; }
    public Guid AreaId { get; private set; }
    public string Name { get; private set; }

    private readonly List<Unit> _units = [];
    public IReadOnlyCollection<Unit> Units => _units.AsReadOnly();
}
