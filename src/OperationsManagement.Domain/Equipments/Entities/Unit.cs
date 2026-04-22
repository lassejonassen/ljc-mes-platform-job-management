using OperationsManagement.Domain._Shared;
using OperationsManagement.Domain.Equipments.Enums;
using OperationsManagement.Domain.Equipments.ValueObjects;

namespace OperationsManagement.Domain.Equipments.Entities;

public sealed class Unit : AggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }

    // The "Functional Link" to the Recipe template.
    public Guid? ProcessSegmentId { get; private set; }

    // The "Physical Link" to the UNS.
    public UnsAddress UnsAddress { get; private set; } = null!;

    public UnitStatus Status { get; private set; }

    public bool CanExecute(Guid processSegmentId)
        => ProcessSegmentId == processSegmentId && Status == UnitStatus.Idle;
}
