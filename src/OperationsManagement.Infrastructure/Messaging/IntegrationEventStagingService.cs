using OperationsManagement.Application.Abstractions;
using OperationsManagement.Application.Abstractions.IntegrationEvents;
using OperationsManagement.SharedKernel.IntegrationEvents;

namespace OperationsManagement.Infrastructure.Messaging;

public class IntegrationEventStagingService(
    IntegrationEventBuffer buffer,
    ICorrelationContext correlationContext) : IIntegrationEventPublisher
{
    public Task PublishAsync<T>(T integrationEvent, CancellationToken ct = default)
        where T : class, IIntegrationEvent
    {
        if (integrationEvent is IntegrationEvent baseEvent)
        {
            integrationEvent.CorrelationId = correlationContext.CorrelationId;
        }

        buffer.Add(integrationEvent);
        return Task.CompletedTask;
    }
}