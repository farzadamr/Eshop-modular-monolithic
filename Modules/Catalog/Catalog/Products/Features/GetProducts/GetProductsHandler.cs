using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Features.GetProducts
{
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
            // mapping Product entity to productDto
            var productDtos = ProjectToProductDto(products);
            
            return new GetProductResult(productDtos);
        }

        private List<ProductDto> ProjectToProductDto(List<Product> products)
        {
            foreach (var product in products)
            {
                // TODO: use mapster library to mapping
            }
            return [];
        }
    }
}
