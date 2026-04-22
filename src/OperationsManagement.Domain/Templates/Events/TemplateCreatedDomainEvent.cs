using OperationsManagement.Domain._Shared.DomainEvents;

namespace OperationsManagement.Domain.Templates.Events;

public sealed record TemplateCreatedDomainEvent(Guid TemplateId) : DomainEvent;
