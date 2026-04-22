using OperationsManagement.Domain._Shared;

namespace OperationsManagement.Domain.ProductionOrders.Entities;

public sealed class ProductionJobParameter : Entity
{
    public Guid ProductionJobId { get; private set; }
    public Guid SourceId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;
    public string? DataType { get; private set; } = string.Empty;
    public string? Description { get; private set; } = string.Empty;

    public ProductionJob ProductionJob { get; } = null!;


}
