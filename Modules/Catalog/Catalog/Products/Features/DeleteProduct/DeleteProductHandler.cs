namespace Catalog.Products.Features.DeleteProduct;

public record DeleteProductCommand(Guid Id)
    :ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);
internal class DeleteProductHandler(CatalogDbContext _context)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        // delete Product from command object
        // save to database
        // return result

        var product = await _context.Products
            .FindAsync([command.Id], cancellationToken: cancellationToken);

        if (product == null)
            throw new Exception($"Product not found {command.Id}");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
