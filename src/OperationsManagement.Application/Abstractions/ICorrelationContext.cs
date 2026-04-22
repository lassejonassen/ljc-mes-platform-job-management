namespace OperationsManagement.Application.Abstractions;

public interface ICorrelationContext
{
    Guid CorrelationId { get; }
}