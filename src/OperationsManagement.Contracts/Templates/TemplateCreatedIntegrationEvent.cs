using OperationsManagement.SharedKernel.IntegrationEvents;

namespace OperationsManagement.Contracts.Templates;

public record TemplateCreatedIntegrationEvent : IntegrationEvent
{
    public required Guid TemplateId { get; init; }
    public required string TemplateName { get; init; }
}