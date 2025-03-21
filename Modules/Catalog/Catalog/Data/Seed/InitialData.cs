namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(new Guid("2610AE50-5738-4270-9006-7C7D414151C0"), "IPhone 16 Pro Max",["category1"],"Long Description","imageFile", 5000500),
        Product.Create(new Guid("2610AE50-5738-4270-9006-7C7D414151C1"), "IPhone 16 Pro Max",["category1"],"Long Description","imageFile", 5005000),
        Product.Create(new Guid("2610AE50-5738-4270-9006-7C7D414151C2"), "IPhone 16 Pro Max",["category2"],"Long Description","imageFile", 5050000),
        Product.Create(new Guid("2610AE50-5738-4270-9006-7C7D414151C3"), "IPhone 16 Pro Max",["category2"],"Long Description","imageFile", 5500000),
    };
}
