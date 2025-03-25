var builder = WebApplication.CreateBuilder(args);

//Add Services to container!

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

builder.Services
    .AddBasketModule(builder.Configuration)
    .AddCatalogModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);



var app = builder.Build();
//Add HTTP request pipeline configuration!
app
    .UseBasketModule()
    .UseCatalogModule()
    .UseOrderingModule();
app.MapCarter();
app.Run();
