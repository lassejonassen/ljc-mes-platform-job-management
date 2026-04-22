using OperationsManagement.Domain._Shared.DomainEvents;

namespace OperationsManagement.Domain._Shared;

public interface IHasDomainEvents
{
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    void ClearDomainEvents();
}
