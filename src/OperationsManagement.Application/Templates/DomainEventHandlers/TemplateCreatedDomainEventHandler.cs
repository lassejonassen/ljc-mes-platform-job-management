using CleanArchitecture.Application.Abstractions.DomainEvents;
using CleanArchitecture.Application.Abstractions.IntegrationEvents;
using CleanArchitecture.Contracts.Templates;
using Microsoft.Extensions.Logging;
using OperationsManagement.Domain.Templates.Events;
using OperationsManagement.Domain.Templates.Repositories;

namespace CleanArchitecture.Application.Templates.DomainEventHandlers;

public sealed class TemplateCreatedDomainEventHandler(
    ITemplateRepository templateRepository,
    IIntegrationEventPublisher publisher,
    ILogger<TemplateCreatedDomainEventHandler> logger)
    : IDomainEventHandler<TemplateCreatedDomainEvent>
{
    public async Task HandleAsync(TemplateCreatedDomainEvent domainEvent, CancellationToken ct = default)
    {
        logger.LogInformation("Handling TemplateCreatedDomainEvent for TemplateId: {TemplateId}", domainEvent.TemplateId);

        var template = await templateRepository.GetByIdAsync(domainEvent.TemplateId, ct);

        if (template == null)
        {
            logger.LogWarning("Template with ID {TemplateId} not found in repository.", domainEvent.TemplateId);
        }

        var integrationEvent = new TemplateCreatedIntegrationEvent
        {
            TemplateId = template!.Id,
            TemplateName = template.Name
        };

        await publisher.PublishAsync(integrationEvent, ct);
    }
}
