namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
public record CheckoutBasketResponse(bool IsSuccess);

public class CheckoutBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
        {
            //var command = request.Adapt<CheckoutBasketCommand>();

            var command = new CheckoutBasketCommand(
                new BasketCheckoutDto
                {
                    UserName = request.BasketCheckoutDto.UserName,
                    CustomerId = request.BasketCheckoutDto.CustomerId,
                    TotalPrice = request.BasketCheckoutDto.TotalPrice,
                    FirstName = request.BasketCheckoutDto.FirstName,
                    LastName = request.BasketCheckoutDto.LastName,
                    EmailAddress = request.BasketCheckoutDto.EmailAddress,
                    AddressLine = request.BasketCheckoutDto.AddressLine,
                    Country = request.BasketCheckoutDto.Country,
                    State = request.BasketCheckoutDto.State,
                    ZipCode = request.BasketCheckoutDto.ZipCode,
                    CardName = request.BasketCheckoutDto.CardName,
                    CardNumber = request.BasketCheckoutDto.CardNumber,
                    CVV = request.BasketCheckoutDto.CVV,
                    PaymentMethod = request.BasketCheckoutDto.PaymentMethod
                });

            var result = await sender.Send(command);

            var response = result.Adapt<CheckoutBasketResponse>();

            return Results.Ok(response);
        })
            .WithName("CheckoutBasket")
            .Produces<CheckoutBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Checkout Basket")
            .WithDescription("Checkout Basket");
    }
}
