using OperationsManagement.Domain._Shared.DomainEvents;

namespace OperationsManagement.Application.Abstractions.DomainEvents;

public interface IDomainEventHandler<in TEvent>
    where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent domainEvent, CancellationToken ct = default);
}
