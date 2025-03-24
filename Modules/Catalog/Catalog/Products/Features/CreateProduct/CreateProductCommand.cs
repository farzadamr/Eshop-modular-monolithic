using MediatR;

namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand
    (string name, List<string> category, string description, string imageFile, decimal price)
    : IRequest<CreateProductResult>;
public record CreateProductResult
    (Guid Id);

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Business Logic
        throw new NotImplementedException();
    }
}
