using BuildingBlocks.CQRS;
using Catalog.Api.Models;
using MediatR;

namespace Catalog.Api.Products.CreateProduct;

public record CreateProducResult(Guid Id);
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProducResult>;
internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProducResult>
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

        // TODO
        //Save to Database

        return new CreateProducResult(Guid.NewGuid());
    }
}
