using OperationsManagement.Domain.ProductionOrders.Entities;
using OperationsManagement.Domain.ProductionOrders.Enums;
using OperationsManagement.Domain.ProductionOrders.ValueObjects;

namespace OperationsManagement.Domain.ProductionOrders.Aggregates;

public sealed class ProductionOrder : AggregateRoot
{
    public string OrderNumber { get; private set; } = string.Empty; // This should batch the ErpReference.OrderNumber if OrderSource is Erp.
    public OrderSource Source { get; private set; }
    public ErpReference? ErpLink { get; private set; }
    public OrderStatus Status { get; private set; }

    public string MaterialId { get; private set; } = string.Empty;
    public decimal TargetQuantity { get; private set; }

    // Child entities (Work Performance units)
    private readonly List<ProductionJob> _jobs = [];
    public IReadOnlyCollection<ProductionJob> Jobs => _jobs.AsReadOnly();

    //public static Result<ProductionOrder> CreateFromErp(ErpReference erpRef, string materialId, decimal quantity)
    //{

    //}
}
