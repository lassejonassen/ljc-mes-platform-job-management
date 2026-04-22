using OperationsManagement.Domain._Shared;
using OperationsManagement.Domain.ProductionOrders.Errors;

namespace OperationsManagement.Domain.ProductionOrders.ValueObjects;

public sealed class ErpReference(string orderNumber, string systemSource, DateTime integratedAtUtc) : ValueObject
{
    public string OrderNumber { get; init; } = orderNumber;
    public string SystemSource { get; init; } = systemSource;
    public DateTime IntegratedAtUtc { get; init; }  = integratedAtUtc;

    public static Result<ErpReference> Create(string orderNumber, string systemSource, DateTime integratedAtUtc)
    {
        if (string.IsNullOrWhiteSpace(orderNumber))
            return Result.Failure<ErpReference>(ProductionOrderErrors.ErpRefInvalidOrderNumber);

        if (string.IsNullOrWhiteSpace(systemSource))
            return Result.Failure<ErpReference>(ProductionOrderErrors.ErpRefInvalidSystemSource);

        var erpReference = new ErpReference(orderNumber, systemSource, integratedAtUtc);

        return Result.Success(erpReference);
    }



    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
