namespace Catalog.Products.Features.GetProducts;

public record GetProductQuery()
    : IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<ProductDto> Products);
internal class GetProductsHandler(CatalogDbContext _context)
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        // get Product using context
        // return result
        var products = await _context.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        // mapping Product entity to productDto using Mapster
        var productDtos = products.Adapt<List<ProductDto>>();
        
        return new GetProductResult(productDtos);
    }
}
