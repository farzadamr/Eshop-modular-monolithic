namespace Catalog.Products.Features.GetProductById;

public record GetProductByIdQuery(Guid Id)
    : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(ProductDto Product);
internal class GetProductByIdHandler(CatalogDbContext _context)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // get Product by id using context
        //return result

        var product = await _context.Products
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        if (product == null)
            throw new Exception($"Product not found: {query.Id}");
        
        // mapping product entity to productDto
        var productDto = product.Adapt<ProductDto>();

        return new GetProductByIdResult(productDto);
    }
}
