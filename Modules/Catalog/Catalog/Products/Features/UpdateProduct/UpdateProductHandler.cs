using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Features.UpdateProduct
{
    public record UpdateProductCommand(ProductDto Product)
        : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);

    internal class UpdateProductHandler(CatalogDbContext _context)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            // update Product from command object
            // save to database
            // return result

            var product = await _context.Products
                .FindAsync([command.Product.Id], cancellationToken: cancellationToken);
            
            if (product == null)
                throw new Exception($"Product not found: {command.Product.Id}");
            
            UpdateProductWithValue(product, command.Product);

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }

        private void UpdateProductWithValue(Product product, ProductDto command)
        {
            product.Update(
                command.Name,
                command.Category,
                command.Description,
                command.ImageFile,
                command.Price);
        }
    }
}
