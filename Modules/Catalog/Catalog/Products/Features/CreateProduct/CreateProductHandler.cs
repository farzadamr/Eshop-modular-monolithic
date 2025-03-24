namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand(ProductDto product)
    : ICommand<CreateProductResult>;
public record CreateProductResult
    (Guid Id);

public class CreateProductCommandHandler(CatalogDbContext _context)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // create Product entity from command object
        // save to database
        // return result

        var product = CreateNewProduct(command.product);

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }

    private Product CreateNewProduct(ProductDto productDto)
    {
        var product = Product.Create(
            Guid.NewGuid(),
            productDto.Name,
            productDto.Category,
            productDto.Description,
            productDto.ImageFile,
            productDto.Price);

        return product;
    }
}
