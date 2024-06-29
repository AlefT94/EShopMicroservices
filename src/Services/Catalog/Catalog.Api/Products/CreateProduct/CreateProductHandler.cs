using BuildingBlocks.CQRS;
using Catalog.Api.Models;
using Marten;

namespace Catalog.Api.Products.CreateProduct;

public record CreateProducResult(Guid Id);
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProducResult>;
internal class CreateProductCommandHandler (IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProducResult>
{
    public async Task<CreateProducResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
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
