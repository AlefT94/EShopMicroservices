﻿using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.API.Endpoints;

/* Accepts a CreateOrderRequest object
 * Maps the request to a CreateOrderCommand
 * Uses MediatR to send the command to the corresponding handler
 * Returns a response with the created order ID*/

public record CreateOrderRequest(OrderDto Order);
public record CreateOderResponse(Guid Id);
public class CreateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async(CreateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateOrderCommand>();

            var result = await sender.Send(command);
            var response = result.Adapt<CreateOderResponse>();

            return Results.Created($"/orders/${response.Id}", response);
        })
        .WithName("CreateOrder")
        .Produces<CreateOderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}
