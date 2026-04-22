using OperationsManagement.SharedKernel;

namespace OperationsManagement.Infrastructure;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}