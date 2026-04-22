using OperationsManagement.Domain.ProductionOrders.Aggregates;

namespace OperationsManagement.Domain.ProductionOrders.Errors;

public static class ProductionOrderErrors
{
    private const string Prefix = nameof(ProductionOrder);

    public static readonly Error ErpRefInvalidOrderNumber
        = new($"{Prefix}.ErpRefInvalidOrderNumber", "The Order Number passed to the ErpReference is invalid", ErrorType.Failure);

    public static readonly Error ErpRefInvalidSystemSource
    = new($"{Prefix}.ErpRefInvalidSystemSource", "The System Source passed to the ErpReference is invalid", ErrorType.Failure);
}
