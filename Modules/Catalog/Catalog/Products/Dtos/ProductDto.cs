using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Dtos
{
    public record ProductDto(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price
        );
    
}
