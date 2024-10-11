﻿using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler 
    (ISender sender, ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        // Create new order and start order fullfilment process
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        //Create full order with incoming event data
        var addressDto = new AddressDto(message.FirstName,message.LastName,message.EmailAddress,message.AddressLine,message.Country,message.State,message.ZipCode);
        var paymentoDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentoDto,
            Status: Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems: [
                new OrderItemDto(orderId,new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"), 5, 10),
                new OrderItemDto(orderId,new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"), 2, 10)
                ]
            );

        return new CreateOrderCommand(orderDto);
    }
}
