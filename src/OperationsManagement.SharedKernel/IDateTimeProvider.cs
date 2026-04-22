namespace OperationsManagement.SharedKernel;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}