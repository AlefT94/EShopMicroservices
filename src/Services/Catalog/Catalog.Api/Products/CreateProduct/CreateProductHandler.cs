namespace Catalog.Api.Products.CreateProduct;

public record CreateProducResult(Guid Id);
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProducResult>;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image File is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greather than 0");
    }
}

internal class CreateProductCommandHandler (IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
    : ICommandHandler<CreateProductCommand, CreateProducResult>
{
    public async Task<CreateProducResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("CreateProductCommandHandler.Handle called with {@Query}", command);
        
        //Create Product Entity from command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //save to Database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //return result
        return new CreateProducResult(product.Id);
    }
}
