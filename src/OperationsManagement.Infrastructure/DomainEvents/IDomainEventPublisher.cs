using OperationsManagement.Domain._Shared.DomainEvents;

namespace OperationsManagement.Infrastructure.DomainEvents;

public interface IDomainEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct = default);
}