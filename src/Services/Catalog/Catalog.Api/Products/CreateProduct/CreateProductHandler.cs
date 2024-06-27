using MediatR;

namespace Catalog.Api.Products.CreateProduct;

public record CreateProducResult(Guid Id);
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : IRequest<CreateProducResult>;
internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProducResult>
{
    public Task<CreateProducResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Business logic to create a product
        throw new NotImplementedException();
    }
}
