using Basket;
using Catalog;
using Ordering;
var builder = WebApplication.CreateBuilder(args);

//Add Services to container!
builder.Services
    .AddBasketModule(builder.Configuration)
    .AddCatalogModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);



var app = builder.Build();


app.Run();
