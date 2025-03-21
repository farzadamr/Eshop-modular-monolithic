namespace Catalog.Data.Seed;

public class CatalogDataSeeder(CatalogDbContext _context) 
    : IDataSeeder
{
    public async Task SeedAllAsync()
    {
        if(!await _context.Products.AnyAsync())
        {
            await _context.Products.AddRangeAsync(InitialData.Products);
            await _context.SaveChangesAsync();
        }
    }
}
