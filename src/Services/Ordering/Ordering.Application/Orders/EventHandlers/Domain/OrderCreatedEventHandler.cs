using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler
    (ILogger<OrderCreatedEventHandler> logger, IFeatureManager featureManager, IPublishEndpoint publisherEndpoint) : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        //Uses a feature to enable/disable this funcionalite
        if(await featureManager.IsEnabledAsync("OrderFullfilment"))
        {
            var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
            await publisherEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        }
    }
}
